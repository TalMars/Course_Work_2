using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseWork_2.ViewModel
{
    public class AddSettingsViewModel : NotifyPropertyChanged
    {
        private int userId;

        private bool _fronCameraIsOn;
        private bool _touchesIsOn;

        private ICommand _cancelCommand;
        private ICommand _doneCommand;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;

        public AddSettingsViewModel(int _userId)
        {
            //GoBack Navigation
            RegisterGoBackEventHandlers();

            FrontCameraIsOn = true;
            TouchesIsOn = true;

            userId = _userId;
        }

        #region back event
        private void RegisterGoBackEventHandlers()
        {
            requestHandler = (o, ea) =>
            {
                GoBackFunc();
                ea.Handled = true;
            };
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += requestHandler;

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                pressedHandler = (o, ea) =>
                {
                    GoBackFunc();
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

        #region properties
        public bool TouchesIsOn
        {
            get { return _touchesIsOn; }
            set
            {
                Set(ref _touchesIsOn, value);
            }
        }

        public bool FrontCameraIsOn
        {
            get { return _fronCameraIsOn; }
            set { Set(ref _fronCameraIsOn, value); }
        }
        #endregion

        #region events
        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new Command(() => GoBackFunc())); }
        }

        private void GoBackFunc()
        {
            Windows.UI.Xaml.Controls.Frame frame = (Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content;
            frame.BackStack.Clear();
            frame.Navigate(typeof(DetailsUserPage), userId);
        }

        public ICommand DoneCommand
        {
            get { return _doneCommand ?? (_doneCommand = new Command(() => DoneFunc())); }
        }

        private void DoneFunc()
        {
            using (var db = new PrototypingContext())
            {
                Record recod = db.Records.Add(new Record() { UserId = userId }).Entity;
                db.RecordSettings.Add(new RecordSettings()
                {
                    RecordId = recod.RecordId,
                    FrontCamera = _fronCameraIsOn,
                    Touches = _touchesIsOn
                });
                db.SaveChanges();
            }

            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ReviewPrototypePage), userId);
        }
        #endregion
    }
}
