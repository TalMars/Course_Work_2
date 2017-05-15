using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace CourseWork_2.ViewModel
{
    public class DetailsUserViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<Record> _records;
        private User _userModel;
        private Record _selectedItem;
        private bool _isOpenCommandBar;

        private ICommand _goBackCommand;
        private ICommand _openAppBarCommand;
        private ICommand _resultScreensCommand;
        private ICommand _addCommand;
        private ICommand _editCommand;
        private ICommand _removeCommad;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;

        public DetailsUserViewModel(int userId)
        {
            IsOpenCommandBar = false;

            //GoBack Navigation
            RegisterGoBackEventHandlers();

            UpdateRecordList(userId);
        }

        private void UpdateRecordList(int userId)
        {
            using (var db = new PrototypingContext())
            {
                UserModel = db.Users.Single(u => u.UserId == userId);
                Records = new ObservableCollection<Record>(db.Records.Where(r => r.UserId == userId));
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
        public ObservableCollection<Record> Records
        {
            get { return _records; }
            set { _records = value; OnPropertyChanged("Records"); }
        }

        public User UserModel
        {
            get { return _userModel; }
            set { _userModel = value; OnPropertyChanged("UserModel"); }
        }

        public Record SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set(ref _selectedItem, value);
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ResultRecordPage), value);
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
            frame.Navigate(typeof(DetailsPrototypePage), UserModel.PrototypeId);
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
                return _addCommand ?? (_addCommand = new Command(() => AddFunc()));
            }
        }

        private void AddFunc()
        {
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddSettingsPage), UserModel.UserId);
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
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddUserPage), UserModel);
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
                User user = db.Users.Single(u => u.UserId == UserModel.UserId);
                await db.Entry(user).Reference(u => u.Prototype).LoadAsync();

                try
                {
                    StorageFolder prototypeFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(user.Prototype.Name + "_" + user.PrototypeId);
                    StorageFolder userFolder = await prototypeFolder.GetFolderAsync(user.Name + "_" + user.UserId);
                    await userFolder.DeleteAsync();
                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Diagnostics.Debug.WriteLine("User folder not found");
                }

                db.Users.Remove(user);
                db.SaveChanges();
            }
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsPrototypePage), UserModel.PrototypeId);
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
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ResultRecordPage), UserModel);
        }

        public async Task DeleteRecord(Record record)
        {
            using (var db = new PrototypingContext())
            {
                Record findRecord = db.Records.Single(r => r.RecordId == record.RecordId);
                await db.Entry(findRecord).Reference(r => r.User).LoadAsync();
                User userParent = findRecord.User;
                await db.Entry(userParent).Reference(u => u.Prototype).LoadAsync();
                try
                {
                    StorageFolder prototypeFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync(userParent.Prototype.Name + "_" + userParent.PrototypeId);
                    StorageFolder userFolder = await prototypeFolder.GetFolderAsync(userParent.Name + "_" + userParent.UserId);
                    StorageFolder recordFolder = await userFolder.GetFolderAsync("Record_" + findRecord.RecordId);
                    await recordFolder.DeleteAsync();
                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Diagnostics.Debug.WriteLine("Prototype/User folder not found");
                }

                db.Records.Remove(findRecord);
                db.SaveChanges();
            }
            UpdateRecordList(record.UserId);
        }
        #endregion
    }
}
