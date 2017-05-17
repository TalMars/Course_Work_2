using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Emotions;
using CourseWork_2.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork_2.ViewModel
{
    public class SummaryEmotionsViewModel : NotifyPropertyChanged
    {
        private int _prototypeId;
        private int _userId;
        private int _recordId;
        private EmotionMeanScores scores;
        private uint max;


        private ICommand _goBackCommand;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;

        private ObservableCollection<EmotionResultDisplayItem> _items;

        public SummaryEmotionsViewModel()
        {
            _prototypeId = -1;
            _userId = -1;
            _recordId = -1;
            scores = new EmotionMeanScores();
            max = 0;

            //GoBack Navigation
            RegisterGoBackEventHandlers();
        }

        public void LoadEmotionsForPrototype(int prototypeId)
        {
            _prototypeId = prototypeId;

            using (var db = new PrototypingContext())
            {
                Prototype prototype = db.Prototypes
                    .Include(p => p.Users)
                        .ThenInclude(u => u.Records)
                            .ThenInclude(r => r.ResultEmotion)
                                .ThenInclude(f => f.Scores)
                    .Single(p => p.PrototypeId == prototypeId);
                foreach (User user in prototype.Users)
                {
                    foreach (Record record in user.Records)
                    {
                        foreach (EmotionFragment fragment in record.ResultEmotion)
                        {
                            foreach (EmotionMeanScores score in fragment.Scores)
                            {
                                scores.AngerScore += score.AngerScore;
                                scores.ContemptScore += score.ContemptScore;
                                scores.DisgustScore += score.DisgustScore;
                                scores.FearScore += score.FearScore;
                                scores.HappinessScore += score.HappinessScore;
                                scores.NeutralScore += score.NeutralScore;
                                scores.SadnessScore += score.SadnessScore;
                                scores.SurpriseScore += score.SurpriseScore;
                                max++;
                            }
                        }
                    }
                }
            }

            SortAndChangeToPercentResult();
        }

        public void LoadEmotionsForUser(int userId)
        {
            _userId = userId;
            using (var db = new PrototypingContext())
            {
                User user = db.Users
                    .Include(u => u.Records)
                        .ThenInclude(r => r.ResultEmotion)
                            .ThenInclude(f => f.Scores)
                    .Single(u => u.UserId == userId);

                foreach (Record record in user.Records)
                {
                    foreach (EmotionFragment fragment in record.ResultEmotion)
                    {
                        foreach (EmotionMeanScores score in fragment.Scores)
                        {
                            scores.AngerScore += score.AngerScore;
                            scores.ContemptScore += score.ContemptScore;
                            scores.DisgustScore += score.DisgustScore;
                            scores.FearScore += score.FearScore;
                            scores.HappinessScore += score.HappinessScore;
                            scores.NeutralScore += score.NeutralScore;
                            scores.SadnessScore += score.SadnessScore;
                            scores.SurpriseScore += score.SurpriseScore;
                            max++;
                        }
                    }
                }
            }

            SortAndChangeToPercentResult();
        }

        public void LoadEmotionsForRecord(int recordId)
        {
            _recordId = recordId;

            using (var db = new PrototypingContext())
            {
                Record record = db.Records
                    .Include(r => r.ResultEmotion)
                        .ThenInclude(f => f.Scores)
                    .Single(r => r.RecordId == recordId);
                foreach (EmotionFragment fragment in record.ResultEmotion)
                {
                    foreach (EmotionMeanScores score in fragment.Scores)
                    {
                        scores.AngerScore += score.AngerScore;
                        scores.ContemptScore += score.ContemptScore;
                        scores.DisgustScore += score.DisgustScore;
                        scores.FearScore += score.FearScore;
                        scores.HappinessScore += score.HappinessScore;
                        scores.NeutralScore += score.NeutralScore;
                        scores.SadnessScore += score.SadnessScore;
                        scores.SurpriseScore += score.SurpriseScore;
                        max++;
                    }
                }
            }

            SortAndChangeToPercentResult();
        }

        private EmotionResultDisplayItem[] SortEmotionResult(EmotionMeanScores scores)
        {
            EmotionResultDisplayItem[] resultDisplay = null;
            if (scores != null)
            {
                resultDisplay = new EmotionResultDisplayItem[8];

                resultDisplay[0] = new EmotionResultDisplayItem { Emotion = "Anger", Score = scores.AngerScore };
                resultDisplay[1] = new EmotionResultDisplayItem { Emotion = "Contempt", Score = scores.ContemptScore };
                resultDisplay[2] = new EmotionResultDisplayItem { Emotion = "Disgust", Score = scores.DisgustScore };
                resultDisplay[3] = new EmotionResultDisplayItem { Emotion = "Fear", Score = scores.FearScore };
                resultDisplay[4] = new EmotionResultDisplayItem { Emotion = "Happiness", Score = scores.HappinessScore };
                resultDisplay[5] = new EmotionResultDisplayItem { Emotion = "Neutral", Score = scores.NeutralScore };
                resultDisplay[6] = new EmotionResultDisplayItem { Emotion = "Sadness", Score = scores.SadnessScore };
                resultDisplay[7] = new EmotionResultDisplayItem { Emotion = "Surprise", Score = scores.SurpriseScore };

                Array.Sort(resultDisplay, CompareDisplayResults);
            }
            return resultDisplay;
        }

        private int CompareDisplayResults(EmotionResultDisplayItem result1, EmotionResultDisplayItem result2)
        {
            return ((result1.Score == result2.Score) ? 0 : ((result1.Score < result2.Score) ? 1 : -1));
        }

        private EmotionResultDisplayItem[] ChangeScoreToPercent(EmotionResultDisplayItem[] resultItems, uint max)
        {
            foreach (EmotionResultDisplayItem resultItem in resultItems)
            {
                resultItem.Score = Math.Round(resultItem.Score * 100 / max, 2, MidpointRounding.AwayFromZero);
            }
            return resultItems;
        }

        private void SortAndChangeToPercentResult()
        {
            EmotionResultDisplayItem[] itemSource = SortEmotionResult(scores);
            itemSource = ChangeScoreToPercent(itemSource, max);
            Items = new ObservableCollection<EmotionResultDisplayItem>(itemSource);
        }

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
        public ObservableCollection<EmotionResultDisplayItem> Items
        {
            get { return _items; }
            set { Set(ref _items, value); }
        }
        #endregion

        #region events
        public ICommand GoBackCommand
        {
            get { return _goBackCommand = new Command(() => GoBackFunc()); }
        }

        private void GoBackFunc()
        {
            Windows.UI.Xaml.Controls.Frame frame = (Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content;
            frame.BackStack.Clear();
            if (_prototypeId >= 0)
            {
                frame.Navigate(typeof(DetailsPrototypePage), _prototypeId);
            }
            if (_userId >= 0)
            {
                frame.Navigate(typeof(DetailsUserPage), _userId);
            }
            if (_recordId >= 0)
            {
                frame.Navigate(typeof(EmotionsPage), _recordId);
            }
        }
        #endregion

    }
}
