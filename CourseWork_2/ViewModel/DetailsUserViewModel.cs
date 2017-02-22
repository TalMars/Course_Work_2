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

namespace CourseWork_2.ViewModel
{
    public class DetailsUserViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<RecordPrototype> _records;
        private UserPrototype _userModel;
        private RecordPrototype _selectedItem;
        private bool _isOpenCommandBar;

        private ICommand _goBackCommand;
        private ICommand _openAppBarCommand;
        private ICommand _resultScreensCommand;
        private ICommand _addCommand;
        private ICommand _editCommand;
        private ICommand _removeCommad;

        public DetailsUserViewModel(int userId)
        {
            IsOpenCommandBar = false;

            using (var db = new PrototypingContext())
            {
                UserModel = db.Users.Single(u => u.UserPrototypeId == userId);
                Records = new ObservableCollection<RecordPrototype>(db.RecordsPrototype.Where(r => r.UserPrototypeId == userId));
            }
        }

        #region properties
        public ObservableCollection<RecordPrototype> Records
        {
            get { return _records; }
            set { _records = value; OnPropertyChanged("Records"); }
        }

        public UserPrototype UserModel
        {
            get { return _userModel; }
            set { _userModel = value; OnPropertyChanged("UserModel"); }
        }

        public RecordPrototype SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    Set(ref _selectedItem, value);
                    //((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsUserPage), value);
                }
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
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsPrototypePage), UserModel.PrototypeId);
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
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ReviewPrototypePage), UserModel.UserPrototypeId);
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
        private void RemoveFunc()
        {
            using (var db = new PrototypingContext())
            {
                db.Users.Remove(UserModel);
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
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ResultScreensPage), UserModel.UserPrototypeId);
        }
        #endregion
    }
}
