using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Emotions;
using CourseWork_2.Extensions;
using CourseWork_2.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace CourseWork_2.ViewModel
{
    public class EmotionsViewModel : NotifyPropertyChanged
    {
        private bool _ringContentVisibility;
        private bool _checkSubKeyVisibility;
        private string _ringText;
        private string _subscriptionKey;

        private const string subKeyFileName = "SubscriptionKey.txt";
        private string operationLocation;

        private ICommand _goBackCommand;
        private ICommand _saveKeyCommand;
        private ICommand _goToSummaryEmotionsCommand;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;

        private static readonly TimeSpan QueryWaitTime = TimeSpan.FromSeconds(60);
        private DispatcherTimer _emotionSyncTimer;
        private VideoAggregateRecognitionResult _videoResult;

        private Record recordModel;

        private MediaPlayerElement _player;
        private WriteableBitmap[] cropEmotions;
        private EmotionResultDisplayItem _emotion1;
        private EmotionResultDisplayItem _emotion2;
        private EmotionResultDisplayItem _emotion3;

        public EmotionsViewModel(int recordId)
        {
            cropEmotions = new WriteableBitmap[8];
            _subscriptionKey = string.Empty;
            operationLocation = string.Empty;

            using (var db = new PrototypingContext())
            {
                //check for saving result emotion in the db
                recordModel = db.Records
                    .Include(r => r.ResultEmotion)
                        .ThenInclude(f => f.Scores)
                    .Single(r => r.RecordId == recordId);
            }

            //GoBack Navigation
            RegisterGoBackEventHandlers();
        }

        public async Task LoadSubKey()
        {
            if (recordModel.ResultEmotion.Count == 0)
            {
                CheckSubKeyVisibility = true;
                StorageFile subKeyFile = (StorageFile)await ApplicationData.Current.LocalFolder.TryGetItemAsync(subKeyFileName);
                if (subKeyFile != null)
                {
                    SubscriptionKey = await FileIO.ReadTextAsync(subKeyFile);
                }
            }
            else
            {
                await LoadData();
            }
        }

        private async Task ErrorMessageDialog(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        #region emotion loads
        private async Task LoadData()
        {
            RingText = "Loading data...";
            RingContentVisibility = true;

            //load video in player
            StorageFile videoFile = await StorageFile.GetFileFromPathAsync(recordModel.PathToVideo);
            MediaPlayerElement player = new MediaPlayerElement();
            player.AreTransportControlsEnabled = true;
            player.Source = MediaSource.CreateFromStorageFile(videoFile);
            VideoPlayer = player;

            //if db haven't result emotion, then get result from emotion api microsoft cognitive service and save in db
            if (recordModel.ResultEmotion.Count == 0)
            {
                if (string.IsNullOrEmpty(recordModel.OperationLocation))
                {
                    //video should < 100MB
                    var fileProps = await videoFile.GetBasicPropertiesAsync();
                    double sizeFileMb = (double)fileProps.Size / 1024 / 1024;
                    if (sizeFileMb < 100)
                    {
                        await Processing(videoFile);
                    }
                    else
                    {
                        await ErrorMessageDialog("The video file size exceeds 100 MB");
                        GoBackFunc();
                    }
                }
                else
                {
                    operationLocation = recordModel.OperationLocation;
                    VideoAggregateRecognitionResult operationResult = await DetectEmotion(operationLocation);
                    if (operationResult != null)
                    {
                        _videoResult = operationResult;
                        await SaveResultInDb(_videoResult);
                    }
                }
            }

            //crops emotions
            StorageFile emotionsFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Resources/Emoji.png"));
            await GetEmotionImages(emotionsFile);

            //create timer which sync emotion for time
            _emotionSyncTimer = new DispatcherTimer();
            _emotionSyncTimer.Interval = TimeSpan.FromMilliseconds(500);
            _emotionSyncTimer.Tick += (e2, s) => { UpdateEmotionForTime(); };
            _emotionSyncTimer.Start();

            RingContentVisibility = false;
        }

        private async Task Processing(StorageFile videoFile)
        {
            VideoAggregateRecognitionResult operationResult = await UploadAndDetectEmotions(videoFile);
            if (operationResult != null)
            {
                _videoResult = operationResult;
                await SaveResultInDb(_videoResult);
            }
        }

        private async Task SaveResultInDb(VideoAggregateRecognitionResult videoResult)
        {
            RingText = "Save in DB...";
            using (var db = new PrototypingContext())
            {
                Record record = db.Records.Single(r => r.RecordId == recordModel.RecordId);
                record.EmotionVideoTimeScale = videoResult.Timescale;

                List<EmotionFragment> fragments = new List<EmotionFragment>();
                foreach (var videoFragment in videoResult.Fragments)
                {
                    if (videoFragment != null && videoFragment.Events != null)
                    {
                        List<EmotionMeanScores> scores = new List<EmotionMeanScores>();
                        foreach (VideoAggregateEvent[] videoEvents in videoFragment.Events)
                        {
                            if (videoEvents.Length > 0)
                            {
                                Scores videoScores = videoEvents[0].WindowMeanScores;
                                scores.Add(new EmotionMeanScores()
                                {
                                    AngerScore = videoScores.Anger,
                                    ContemptScore = videoScores.Contempt,
                                    DisgustScore = videoScores.Disgust,
                                    FearScore = videoScores.Fear,
                                    HappinessScore = videoScores.Happiness,
                                    NeutralScore = videoScores.Neutral,
                                    SadnessScore = videoScores.Sadness,
                                    SurpriseScore = videoScores.Surprise
                                });
                            }
                        }
                        fragments.Add(new EmotionFragment()
                        {
                            Duration = videoFragment.Duration,
                            Interval = videoFragment.Interval,
                            Start = videoFragment.Start,
                            Scores = scores
                        });
                    }
                }

                record.ResultEmotion = fragments;
                await db.SaveChangesAsync();
                recordModel.EmotionVideoTimeScale = record.EmotionVideoTimeScale;
                recordModel.ResultEmotion = fragments;
            }
        }

        private async Task<VideoAggregateRecognitionResult> UploadAndDetectEmotions(StorageFile videoFile)
        {
            VideoAggregateRecognitionResult aggResult = null;
            EmotionServiceClient emotionServiceClient = new EmotionServiceClient(_subscriptionKey);
            try
            {
                using (Stream videoFileStream = await videoFile.OpenStreamForReadAsync()) //File.OpenRead(videoFilePath)
                {
                    RingText = "Uploading video...";
                    byte[] bytesVideo;
                    using (var memoryStream = new MemoryStream())
                    {
                        await videoFileStream.CopyToAsync(memoryStream);
                        bytesVideo = memoryStream.ToArray();
                    }
                    //get operation id on service
                    operationLocation = await UploadEmotion(bytesVideo);

                    //save operation-location
                    using (var db = new PrototypingContext())
                    {
                        Record record = db.Records.Single(r => r.RecordId == recordModel.RecordId);
                        record.OperationLocation = operationLocation;
                        db.SaveChanges();
                        recordModel.OperationLocation = operationLocation;
                    }
                    //get result emotions from id operation
                    aggResult = await DetectEmotion(operationLocation);

                }
            }
            catch (Exception)
            {
                await ErrorMessageDialog("Oops, error. Check your internet connection.");
                GoBackFunc();
            }


            return aggResult;
        }

        private async Task<string> UploadEmotion(byte[] byteData)
        {
            string operationLocation = string.Empty;
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(10);
            client.DefaultRequestHeaders.ExpectContinue = false;
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);
            var uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognizeinvideo?outputStyle=aggregate";
            HttpResponseMessage response;

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    IEnumerable<string> values;
                    if (response.Headers.TryGetValues("Operation-Location", out values))
                    {
                        operationLocation = values.First();
                    }
                }
                else
                {
                    string message = ErrorMessage(response, false);
                    await ErrorMessageDialog(message);
                }
            }

            return operationLocation;
        }

        private async Task<VideoAggregateRecognitionResult> DetectEmotion(string operationLocation)
        {
            VideoAggregateRecognitionResult result = null;
            string errorMessage = string.Empty;

            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(10);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            RingText = "Processing with server status...";
            HttpResponseMessage response = null;
            int attemptNumber = 1;
            VideoOperationResult videoResult;
            while (true)
            {
                response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, operationLocation));
                videoResult = ResponseResult(response);

                if (videoResult != null && (videoResult.Status == VideoOperationStatus.Succeeded || videoResult.Status == VideoOperationStatus.Failed))
                {
                    break;
                }
                if (videoResult == null)
                {
                    errorMessage = ErrorMessage(response, true);
                    break;
                }

                RingText = string.Format("Server status ({0}): {1}, wait {2} seconds...", attemptNumber, videoResult.Status, QueryWaitTime.TotalSeconds);
                attemptNumber++;
                await Task.Delay(QueryWaitTime);
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await ErrorMessageDialog(errorMessage);
            }
            else
            {
                if (videoResult.Status == VideoOperationStatus.Failed)
                {
                    await ErrorMessageDialog("Recognize emotions failed.");
                }
                else
                {
                    result = ((VideoOperationInfoResult<VideoAggregateRecognitionResult>)videoResult).ProcessingResult;
                }
            }

            return result;
        }

        private VideoOperationResult ResponseResult(HttpResponseMessage response)
        {
            VideoOperationResult videoResult = null;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                content = content.Replace("\\", "");
                if (content.Contains("processingResult"))
                {
                    int i1 = content.IndexOf("processingResult") + 18;
                    content = content.Remove(i1, 1);
                    int i2 = content.LastIndexOf('}') - 3;
                    content = content.Remove(i2, 3);
                }
                videoResult = Newtonsoft.Json.JsonConvert.DeserializeObject<VideoOperationInfoResult<VideoAggregateRecognitionResult>>(content);
            }
            return videoResult;
        }

        private string ErrorMessage(HttpResponseMessage response, bool isCheckStatus)
        {
            string result = string.Empty;
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    if (isCheckStatus)
                        result = "The operation ID is not specified.";
                    else
                        result = "Video size is too small or too big.";
                    break;
                case System.Net.HttpStatusCode.NotFound:
                    result = "The operation with given operation ID not found.";
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    result = "Access denied due to invalid subscription key.";
                    break;
                case System.Net.HttpStatusCode.Forbidden:
                    result = "Quota limit exceeded.";
                    break;
                case (System.Net.HttpStatusCode)429:
                    result = "Rate limit exceeded.";
                    break;
                default:
                    result = "No response status";
                    break;
            }
            return result;
        }

        private void UpdateEmotionForTime()
        {
            if (_player.MediaPlayer.PlaybackSession.PlaybackState == Windows.Media.Playback.MediaPlaybackState.Playing && recordModel.ResultEmotion != null && recordModel.ResultEmotion.Count > 0)
            {
                // get the current position of the video in terms of the timescale
                var currentTimeInTimescale = _player.MediaPlayer.PlaybackSession.Position.TotalSeconds * recordModel.EmotionVideoTimeScale;

                // the emotion results are aggregates of a two second window
                // get the emotion for one second in the future, so that the emotion displayed is the aggregate for the actual part of the video we're showing
                currentTimeInTimescale += recordModel.EmotionVideoTimeScale;
                // find the fragment that represents where we are in the video
                var currentFragment = recordModel.ResultEmotion.SingleOrDefault(f => f.Start < currentTimeInTimescale && f.Start + f.Duration > currentTimeInTimescale);
                if (currentFragment != null && currentFragment.Scores != null)
                {
                    // work out which block of events represents the current time
                    int timeIndex = (int)Math.Floor((currentTimeInTimescale - currentFragment.Start) / currentFragment.Interval.Value);

                    // find the closest block of events that actually contains data
                    var closestEventIndex = currentFragment.Scores.Select((e, i) => i).OrderBy((i) => Math.Abs(i - timeIndex)).FirstOrDefault();

                    // get the scores that occured at this time
                    var scores = currentFragment.Scores[closestEventIndex];
                    // only show the first event per time period
                    ListVideoEmotionResult(scores);
                }
            }
        }

        private void ListVideoEmotionResult(EmotionMeanScores scores)
        {
            if (scores != null)
            {
                EmotionResultDisplayItem[] resultDisplay = new EmotionResultDisplayItem[8];
                resultDisplay[0] = new EmotionResultDisplayItem { Emotion = "Anger", Score = scores.AngerScore, CroppedImage = cropEmotions[0] };
                resultDisplay[1] = new EmotionResultDisplayItem { Emotion = "Contempt", Score = scores.ContemptScore, CroppedImage = cropEmotions[1] };
                resultDisplay[2] = new EmotionResultDisplayItem { Emotion = "Disgust", Score = scores.DisgustScore, CroppedImage = cropEmotions[2] };
                resultDisplay[3] = new EmotionResultDisplayItem { Emotion = "Fear", Score = scores.FearScore, CroppedImage = cropEmotions[3] };
                resultDisplay[4] = new EmotionResultDisplayItem { Emotion = "Happiness", Score = scores.HappinessScore, CroppedImage = cropEmotions[4] };
                resultDisplay[5] = new EmotionResultDisplayItem { Emotion = "Neutral", Score = scores.NeutralScore, CroppedImage = cropEmotions[5] };
                resultDisplay[6] = new EmotionResultDisplayItem { Emotion = "Sadness", Score = scores.SadnessScore, CroppedImage = cropEmotions[6] };
                resultDisplay[7] = new EmotionResultDisplayItem { Emotion = "Surprise", Score = scores.SurpriseScore, CroppedImage = cropEmotions[7] };

                Array.Sort(resultDisplay, CompareDisplayResults);

                Emotion1 = resultDisplay[0];

                Emotion2 = resultDisplay[1];

                Emotion3 = resultDisplay[2];
            }
        }

        private int CompareDisplayResults(EmotionResultDisplayItem result1, EmotionResultDisplayItem result2)
        {
            return ((result1.Score == result2.Score) ? 0 : ((result1.Score < result2.Score) ? 1 : -1));
        }

        private async Task GetEmotionImages(StorageFile emotionsFile)
        {
            for (int i = 0; i < 8; i++)
            {
                cropEmotions[i] = await CropBitmapHelper.GetCroppedBitmapAsync(emotionsFile, new Point(i * 96, 0), new Size(96, 96), 1);
            }
        }

        #endregion

        #region back event
        private void RegisterGoBackEventHandlers()
        {
            requestHandler = (o, ea) =>
            {
                ea.Handled = true;
                GoBackFunc();
            };
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += requestHandler;

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                pressedHandler = (o, ea) =>
                {
                    ea.Handled = true;
                    GoBackFunc();
                };
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += pressedHandler;
            }
        }

        public void UnregisterRequestEventHander()
        {
            if (requestHandler != null)
            {
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= requestHandler;
            }
        }

        public void UnregisterPressedEventHadler()
        {
            if (pressedHandler != null)
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed -= pressedHandler;
            }
        }
        #endregion

        #region properties
        public MediaPlayerElement VideoPlayer
        {
            get { return _player; }
            set { Set(ref _player, value); }
        }

        public EmotionResultDisplayItem Emotion1
        {
            get { return _emotion1; }
            set { Set(ref _emotion1, value); }
        }

        public EmotionResultDisplayItem Emotion2
        {
            get { return _emotion2; }
            set { Set(ref _emotion2, value); }
        }

        public EmotionResultDisplayItem Emotion3
        {
            get { return _emotion3; }
            set { Set(ref _emotion3, value); }
        }

        public bool CheckSubKeyVisibility
        {
            get { return _checkSubKeyVisibility; }
            set { Set(ref _checkSubKeyVisibility, value); }
        }

        public bool RingContentVisibility
        {
            get { return _ringContentVisibility; }
            set { Set(ref _ringContentVisibility, value); }
        }

        public string RingText
        {
            get { return _ringText; }
            set { Set(ref _ringText, value); }
        }

        public string SubscriptionKey
        {
            get { return _subscriptionKey; }
            set { Set(ref _subscriptionKey, value); }
        }
        #endregion

        #region events
        public ICommand SaveKeyCommand
        {
            get { return _saveKeyCommand ?? (_saveKeyCommand = new Command(async () => await SaveKey())); }
        }

        private async Task SaveKey()
        {
            StorageFile subKeyFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(subKeyFileName, CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(subKeyFile, _subscriptionKey);
            CheckSubKeyVisibility = false;
            await LoadData();
        }

        public ICommand GoToSummaryEmotionsCommand
        {
            get { return _goToSummaryEmotionsCommand = new Command(() => GoToSummaryEmotions()); }
        }

        private void GoToSummaryEmotions()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(SummaryEmotionsPage), recordModel);
        }

        public ICommand GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new Command(() => GoBackFunc()));
            }
        }

        private void GoBackFunc()
        {
            if (!_ringContentVisibility)
            {
                Frame frame = (Frame)Window.Current.Content;
                frame.BackStack.Clear();
                if (recordModel != null)
                {
                    frame.Navigate(typeof(ResultRecordPage), recordModel);
                }
            }
        }

        public void Cleaning()
        {
            if (VideoPlayer != null)
            {
                VideoPlayer.MediaPlayer.Pause();
                VideoPlayer.MediaPlayer.Dispose();
            }
            if (_emotionSyncTimer != null)
                _emotionSyncTimer.Stop();
        }
        #endregion
    }
}
