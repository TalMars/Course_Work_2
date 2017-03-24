using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Extensions_Folder;
using CourseWork_2.HeatMap;
using CourseWork_2.Model;
using CourseWork_2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System.Display;

namespace CourseWork_2.ViewModel
{
    public class ReviewPrototypeViewModel : NotifyPropertyChanged
    {
        private bool isSplitViewPaneOpen;
        private bool _isOnStart;
        private bool _ringContentVisibility;
        private bool _previewVisibility;

        private bool isLastUri;

        private string loadingPageText = "Loading Page...";
        private string screeningText = "Screenshoting...";
        private string _ringText;

        private ICommand _startStopCommand;
        private ICommand _previewVideoCommand;
        private ICommand _cancelCommand;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;

        private int userId;
        private int recordId;
        private string _sourceWebView = null;

        private Windows.UI.Xaml.Controls.CaptureElement _captureElement;
        private MediaCapture _mediaCapture;
        private bool _isPreviewing;
        private DisplayRequest _displayRequest;
        private CameraRotationHelper _rotationHelper;
        private static readonly Guid RotationKey = new Guid("C380465D-2271-428C-9B83-ECEA3B4A85C1");

        private StorageFile videoFile;

        private Windows.UI.Xaml.DispatcherTimer timer;
        private string _timerText;
        private int timerSeconds;

        private List<RecordScreenPrototypeModel> _screens;

        #region ChangeUSerAgent
        private string androidASUS = "Mozilla/5.0 (Linux; Android 6.0.1; ASUS_Z00ED Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.68 Mobile Safari/537.36";

        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        const int URLMON_OPTION_USERAGENT = 0x10000001;
        public void ChangeUserAgent(string Agent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        }
        #endregion

        public ReviewPrototypeViewModel(int _userId)
        {
            ChangeUserAgent(androidASUS);

            _screens = new List<RecordScreenPrototypeModel>();
            IsOnStart = true;
            PreviewVisibility = false;
            isLastUri = false;
            userId = _userId;
            recordId = -1;

            //GoBack Navigation
            RegisterGoBackEventHandlers();

            using (var db = new PrototypingContext())
            {
                UserPrototype user = db.Users.Single(u => u.UserPrototypeId == userId);
                db.Entry(user).Reference(u => u.Prototype).Load();
                SourceWebView = user.Prototype.Url;
            }
        }

        #region back event
        private void RegisterGoBackEventHandlers()
        {
            requestHandler = (o, ea) =>
            {
                CancelFunc();
                ea.Handled = true;
            };
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += requestHandler;

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                pressedHandler = (o, ea) =>
                {
                    CancelFunc();
                    ea.Handled = true;
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

        #region media capture methods
        public async Task MediaCaptureInitialization()
        {
            _mediaCapture = new MediaCapture();
            _displayRequest = new DisplayRequest();
            DeviceInformation cameraDevice = await GetFrontalCameraDevice();
            MediaCaptureInitializationSettings mediaInitSettings = new MediaCaptureInitializationSettings { VideoDeviceId = cameraDevice.Id };
            await _mediaCapture.InitializeAsync(mediaInitSettings);

            _rotationHelper = new CameraRotationHelper(cameraDevice.EnclosureLocation);
            _rotationHelper.OrientationChanged += RotationHelper_OrientationChanged;

            CaptureElement.Source = _mediaCapture;
            CaptureElement.FlowDirection = Windows.UI.Xaml.FlowDirection.RightToLeft;
            await _mediaCapture.StartPreviewAsync();
            await SetPreviewRotationAsync();

            _isPreviewing = true;
            PreviewVisibility = true;

            _displayRequest.RequestActive();

            _mediaCapture.RecordLimitationExceeded += MediaCapture_RecordLimitationExceeded;
            _mediaCapture.Failed += MediaCapture_Failed;
        }

        private async void RotationHelper_OrientationChanged(object sender, bool updatePreview)
        {
            if (updatePreview)
            {
                await SetPreviewRotationAsync();
            }
        }

        private async void MediaCapture_RecordLimitationExceeded(MediaCapture sender)
        {
            await StartStopFunc();

            //message record limit!!!
        }

        private void MediaCapture_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            CancelFunc();

            //message error dialog!!!
        }

        private async Task SetPreviewRotationAsync()
        {
            // Add rotation metadata to the preview stream to make sure the aspect ratio / dimensions match when rendering and getting preview frames
            var rotation = _rotationHelper.GetCameraPreviewOrientation();
            var props = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview);
            props.Properties.Add(RotationKey, CameraRotationHelper.ConvertSimpleOrientationToClockwiseDegrees(rotation));
            await _mediaCapture.SetEncodingPropertiesAsync(MediaStreamType.VideoPreview, props, null);
        }

        private async Task<string> CreateVideoFile(int recordId)
        {
            string pathToVideo = string.Empty;
            using (var db = new PrototypingContext())
            {
                UserPrototype user = db.Users.Single(u => u.UserPrototypeId == userId);
                await db.Entry(user).Reference(u => u.Prototype).LoadAsync();

                string prototypeName = user.Prototype.Name + "_" + user.PrototypeId;
                string userName = user.Name + "_" + user.UserPrototypeId;
                string recordName = "Record_" + recordId;

                StorageFolder prototypeFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(prototypeName, CreationCollisionOption.OpenIfExists); //PrototypeName + Id
                StorageFolder userFolder = await prototypeFolder.CreateFolderAsync(userName, CreationCollisionOption.OpenIfExists); //UserName + Id
                StorageFolder recordFolder = await userFolder.CreateFolderAsync(recordName, CreationCollisionOption.OpenIfExists);
                videoFile = await recordFolder.CreateFileAsync("videoRecord.mp4", CreationCollisionOption.GenerateUniqueName);

                pathToVideo = videoFile.Path;
            }
            return pathToVideo;
        }

        private async void CleanupCameraAsync()
        {
            if (_mediaCapture != null)
            {
                if (_isPreviewing)
                {
                    PreviewVisibility = false;
                    await _mediaCapture.StopPreviewAsync();
                }
                CaptureElement.Source = null;
                //await CoreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                //{
                if (_displayRequest != null)
                {
                    _displayRequest.RequestRelease();
                }

                await _mediaCapture.StopRecordAsync();
                _mediaCapture.Dispose();
                //});
            }

        }

        public async Task<DeviceInformation> GetFrontalCameraDevice()
        {
            DeviceInformation deviceReturn = null;

            DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);

            foreach (var device in devices)
            {
                if (device.EnclosureLocation.Panel == Panel.Front) //MediaCapture.IsVideoProfileSupported(device.Id) && 
                {
                    deviceReturn = device;
                    break;
                }
            }

            return deviceReturn;
        }
        #endregion

        #region properties
        public string SourceWebView
        {
            get { return _sourceWebView; }
            set { Set(ref _sourceWebView, value); }
        }

        public bool IsSplitViewPaneOpen
        {
            get { return isSplitViewPaneOpen; }
            set { Set(ref isSplitViewPaneOpen, value); }
        }

        public bool IsOnStart
        {
            get { return _isOnStart; }
            set { Set(ref _isOnStart, value); }
        }

        public bool RingContentVisibility
        {
            get { return _ringContentVisibility; }
            set { Set(ref _ringContentVisibility, value); }
        }

        public Windows.UI.Xaml.Controls.CaptureElement CaptureElement
        {
            get
            {
                if (_captureElement == null) _captureElement = new Windows.UI.Xaml.Controls.CaptureElement();
                return _captureElement;
            }
            set
            {
                Set(ref _captureElement, value);
            }
        }

        public bool PreviewVisibility
        {
            get { return _previewVisibility; }
            set { Set(ref _previewVisibility, value); }
        }

        public string RingText
        {
            get { return _ringText; }
            set { Set(ref _ringText, value); }
        }

        public string TimerText
        {
            get { return _timerText; }
            set { Set(ref _timerText, value); }
        }
        #endregion

        #region pane controls events
        public ICommand StartStopCommand
        {
            get
            {
                return _startStopCommand ?? (_startStopCommand = new Command(async () => await StartStopFunc()));
            }
        }

        private async Task StartStopFunc()
        {
            if (_isOnStart)
            {
                TimerInit();
                IsOnStart = false;
                IsSplitViewPaneOpen = false;

                using (var db = new PrototypingContext())
                {
                    RecordPrototype record = db.RecordsPrototype.Add(new RecordPrototype() { CreatedDate = DateTime.Now, UserPrototypeId = userId }).Entity;
                    db.SaveChanges();
                    string pathtoVideo = await CreateVideoFile(record.RecordPrototypeId);
                    record.PathToVideo = pathtoVideo;
                    db.RecordsPrototype.Update(record);
                    recordId = record.RecordPrototypeId;
                    db.SaveChanges();
                }

                var encodingProfile = MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Auto);
                var rotationAngle = CameraRotationHelper.ConvertSimpleOrientationToClockwiseDegrees(_rotationHelper.GetCameraCaptureOrientation());
                encodingProfile.Video.Properties.Add(RotationKey, PropertyValue.CreateInt32(rotationAngle));
                //_mediaRecording = await _mediaCapture.PrepareLowLagRecordToStorageFileAsync(encodingProfile, videoFile);
                await _mediaCapture.StartRecordToStorageFileAsync(encodingProfile, videoFile);
                //await _mediaRecording.StartAsync();
            }
            else
            {
                timer.Stop();
                CleanupCameraAsync();
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ResultScreensPage), _screens);
            }
        }

        public ICommand PreviewVideoCommand
        {
            get
            {
                return _previewVideoCommand ?? (_previewVideoCommand = new Command(() => PreviewVideoFunc()));
            }
        }

        private void PreviewVideoFunc()
        {
            PreviewVisibility = !_previewVisibility;
        }

        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new Command(() => CancelFunc()));
            }
        }

        private async void CancelFunc()
        {
            if (recordId >= 0)
            {
                using (var db = new PrototypingContext())
                {
                    UserPrototype user = db.Users.Single(u => u.UserPrototypeId == userId);
                    RecordPrototype record = db.RecordsPrototype.Last();
                    db.Entry(user).Reference(u => u.Prototype).Load();

                    StorageFolder prototypeFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(user.Prototype.Name + "_" + user.PrototypeId);
                    StorageFolder userFolder = await prototypeFolder.GetFolderAsync(user.Name + "_" + user.UserPrototypeId);
                    StorageFolder recordFolder = await userFolder.GetFolderAsync("Record_" + recordId);
                    await recordFolder.DeleteAsync();

                    db.RecordsPrototype.Remove(record);
                    db.SaveChanges();
                }
            }

            Windows.UI.Xaml.Controls.Frame frame = (Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content;
            frame.BackStack.Clear();
            frame.Navigate(typeof(DetailsUserPage), userId);
        }
        #endregion

        #region Timer Events
        private void TimerInit()
        {
            timer = new Windows.UI.Xaml.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            string hours = (timerSeconds / 3600).ToString();
            string minutes = ((timerSeconds % 3600) / 60).ToString();
            string seconds = (timerSeconds % 60).ToString();

            TimerText = hours + ":" + minutes + ":" + seconds;
            timerSeconds++;
        }
        #endregion

        #region WebView events
        public void WebView_NavigationStarting(Windows.UI.Xaml.Controls.WebView sender, Windows.UI.Xaml.Controls.WebViewNavigationStartingEventArgs args)
        {
            RingText = loadingPageText;
            RingContentVisibility = true;
        }

        public async void WebView_NavigationCompleted(Windows.UI.Xaml.Controls.WebView sender, Windows.UI.Xaml.Controls.WebViewNavigationCompletedEventArgs args)
        {
            string docClickScript = @"if (document.addEventListener) {" +
                    "document.addEventListener(\"click\", PageClicked, false);" +
                "} else {" +
                    "document.attachEvent('onclick', PageClicked);" +
                "}  " +
                "function PageClicked(event){" +
                    "var pointX = event.clientX;" +
                    "var pointY = event.clientY;" +
                    "var uri = document.location.href;" +
                    " window.external.notify('tap:' + pointX + ':' + pointY + ':' + uri);" +
                 "}";
            await sender.InvokeScriptAsync("eval", new string[] { docClickScript }); //set event 'click' on page

            RingContentVisibility = false;
            RingText = screeningText;
        }

        public async void WebView_ScriptNotify(object sender, Windows.UI.Xaml.Controls.NotifyEventArgs e)
        {
            if (e.Value.Contains("tap") && !IsOnStart)
            {
                Windows.UI.Xaml.Controls.WebView webView = (Windows.UI.Xaml.Controls.WebView)sender;

                float x;
                float y;
                string[] arr = e.Value.Split(new char[] { ':' });

                if (!float.TryParse(arr[1], out x))
                {
                    System.Diagnostics.Debug.WriteLine("ErrorX");
                }

                if (!float.TryParse(arr[2], out y))
                {
                    System.Diagnostics.Debug.WriteLine("ErrorY");
                }

                int iX = (int)Math.Round(x);
                int iY = (int)Math.Round(y);
                HeatPoint hp = new HeatPoint(iX, iY);

                int indexFind = _screens.FindIndex(s => s.UriPage.Equals(webView.Source.AbsoluteUri));
                if (indexFind != -1)
                {
                    _screens[indexFind].ListPoints.Add(hp);
                }
                else
                {
                    if (isLastUri)
                    {
                        isLastUri = false;
                        _screens[_screens.Count - 1].ListPoints.Add(hp);
                    }
                    else
                    {
                        isLastUri = true;
                        //screenshot
                        await DoCaptureWebView(webView, hp);
                    }
                }
            }
        }

        private async Task<bool> DoCaptureWebView(Windows.UI.Xaml.Controls.WebView webview, HeatPoint hp)
        {
            bool isOk = true;

            RingContentVisibility = true;

            int screenHeight = (int)webview.ActualHeight;
            int screenWidth = (int)webview.ActualWidth;

            InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream();
            await webview.CapturePreviewToStreamAsync(ms);

            Windows.UI.Xaml.Media.Imaging.WriteableBitmap wb = await HeatMapFunctions.Resize(screenWidth, screenHeight, ms);

            _screens.Add(new RecordScreenPrototypeModel(webview.Source.AbsoluteUri, wb));
            _screens[_screens.Count - 1].ListPoints.Add(hp);

            RingContentVisibility = false;

            return isOk;
        }

        #endregion
    }
}
