using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Pages;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace CourseWork_2.ViewModel
{
    public class DetailsPrototypeViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<User> _users;
        private Prototype _prototypeModel;
        private User _selectedItem;
        private bool _isOpenCommandBar;

        private ICommand _goBackCommand;
        private ICommand _openAppBarCommand;
        private ICommand _resultScreensCommand;
        private ICommand _addCommand;
        private ICommand _editCommand;
        private ICommand _removeCommad;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;

        public DetailsPrototypeViewModel(int prototypeId)
        {
            IsOpenCommandBar = false;

            //GoBack Navigation
            RegisterGoBackEventHandlers();

            UpdateUserList(prototypeId);
        }

        private void UpdateUserList(int prototypeId)
        {
            using (var db = new PrototypingContext())
            {
                PrototypeModel = db.Prototypes.Single(p => p.PrototypeId == prototypeId);
                Users = new ObservableCollection<User>(db.Users.Where(u => u.PrototypeId == prototypeId));
            }
        }

        public async Task DeleteUser(User user)
        {
            using (var db = new PrototypingContext())
            {
                User findUser = db.Users.Single(u => u.UserId == user.UserId);
                await db.Entry(findUser).Reference(u => u.Prototype).LoadAsync();
                try
                {
                    StorageFolder prototypeFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(findUser.Prototype.Name + "_" + findUser.PrototypeId);
                    StorageFolder userFolder = await prototypeFolder.GetFolderAsync(findUser.Name + "_" + findUser.UserId);
                    await userFolder.DeleteAsync();
                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Diagnostics.Debug.WriteLine("Prototype/User folder not found");
                }

                db.Users.Remove(findUser);
                db.SaveChanges();
            }
            UpdateUserList(user.PrototypeId);
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
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { Set(ref _users, value); }
        }

        public Prototype PrototypeModel
        {
            get { return _prototypeModel; }
            set { Set(ref _prototypeModel, value); }
        }

        public User SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set(ref _selectedItem, value);
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsUserPage), value.UserId);
            }
        }

        public bool IsOpenCommandBar
        {
            get { return _isOpenCommandBar; }
            set { Set(ref _isOpenCommandBar, value); }
        }
        #endregion

        #region events
        public ICommand GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new Command(() => GoBackFunc()));
            }
        }
        private void GoBackFunc()
        {
            Windows.UI.Xaml.Controls.Frame frame = (Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content;
            frame.BackStack.Clear();
            frame.Navigate(typeof(PrototypesPage));
        }

        public ICommand OpenAppBarCommand
        {
            get
            {
                return _openAppBarCommand ?? (_openAppBarCommand = new Command(() => IsOpenCommandBar = true));
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new Command(() => AddUserFunc()));
            }
        }

        private void AddUserFunc()
        {
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddUserPage), PrototypeModel);
        }

        public ICommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new Command(() => EditFunc()));
            }
        }
        private void EditFunc()
        {
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddPrototypePage), PrototypeModel);
        }

        public ICommand RemoveCommand
        {
            get
            {
                return _removeCommad ?? (_removeCommad = new Command(() => RemoveFunc()));
            }
        }
        private async void RemoveFunc()
        {
            using (var db = new PrototypingContext())
            {
                try
                {
                    StorageFolder prototypeFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(PrototypeModel.Name + "_" + PrototypeModel.PrototypeId);
                    await prototypeFolder.DeleteAsync();
                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Diagnostics.Debug.WriteLine("Prototype folder not found");
                }

                db.Prototypes.Remove(PrototypeModel);
                db.SaveChanges();
            }
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(PrototypesPage));
        }

        public ICommand ResultScreensCommand
        {
            get
            {
                return _resultScreensCommand ?? (_resultScreensCommand = new Command(() => ResultScreensFunc()));
            }
        }

        private void ResultScreensFunc()
        {
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ResultRecordPage), PrototypeModel);
        }
        #endregion
    }
}
