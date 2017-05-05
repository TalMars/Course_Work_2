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
    public class AddUserViewModel : NotifyPropertyChanged
    {
        private string _nameText;
        private string _biographyText;
        private int prototypeId;
        private ICommand _createCommand;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        private bool _isEdit;
        private User user;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;

        public AddUserViewModel()
        {
            _nameText = "";
            _biographyText = "";

            //GoBack Navigation
            RegisterGoBackEventHandlers();
        }

        public void LoadUser(Prototype _prototype)
        {
            prototypeId = _prototype.PrototypeId;
        }

        public void LoadUser(User _user)
        {
            IsEdit = true;
            user = _user;
            NameText = user.Name;
            BiographyText = user.Biography;
            prototypeId = -1;
        }

        public void LoadUser(int _userId)
        {
            using(var db = new PrototypingContext())
            {
                User _user = db.Users.Single(u => u.UserId == _userId);
                IsEdit = true;
                prototypeId = _user.PrototypeId;
                user = new User() { UserId = _userId };
                NameText = _user.Name;
                BiographyText = _user.Biography;
            }
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
        public string NameText
        {
            get { return _nameText; }
            set { Set(ref _nameText, value); }
        }

        public string BiographyText
        {
            get { return _biographyText; }
            set { Set(ref _biographyText, value); }
        }

        public bool IsEdit
        {
            get { return _isEdit; }
            set { Set(ref _isEdit, value); }
        }
        #endregion

        #region events
        public ICommand CreateCommand
        {
            get
            {
                return _createCommand ?? (_createCommand = new Command(() => CreateFunc()));
            }
        }

        private void CreateFunc()
        {
            if (!NameText.Equals("") && !BiographyText.Equals(""))
            {
                using (var db = new PrototypingContext())
                {
                    db.Users.Add(new User()
                    {
                        Name = NameText,
                        Biography = BiographyText,
                        AddedDate = DateTime.Now,
                        PrototypeId = prototypeId
                    });
                    db.SaveChanges();
                }
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsPrototypePage), prototypeId);
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(() => SaveFunc()));
            }
        }

        private void SaveFunc()
        {
            if (!NameText.Equals("") && !BiographyText.Equals(""))
            {
                using (var db = new PrototypingContext())
                {
                    User findUser = db.Users.Single(u => u.UserId == user.UserId);
                    findUser.Name = NameText;
                    findUser.Biography = BiographyText;
                    db.Users.Update(findUser);
                    db.SaveChanges();
                }
                GoBackFunc();
            }
        }

        public ICommand GoBackCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new Command(() => GoBackFunc()));
            }
        }

        private void GoBackFunc()
        {
            Windows.UI.Xaml.Controls.Frame frame = (Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content;
            frame.BackStack.Clear();
            if (user != null && user.Name != null)
                frame.Navigate(typeof(DetailsUserPage), user.UserId);
            else
                frame.Navigate(typeof(DetailsPrototypePage), prototypeId);
        }
        #endregion
    }
}
