using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace CourseWork_2.ViewModel
{
    public class DetailsPrototypeViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<UserPrototype> _users;
        private Prototype _prototypeModel;
        private UserPrototype _selectedItem;
        private bool _isOpenCommandBar;

        private ICommand _goBackCommand;
        private ICommand _openAppBarCommand;
        private ICommand _resultScreensCommand;
        private ICommand _addCommand;
        private ICommand _editCommand;
        private ICommand _removeCommad;

        public DetailsPrototypeViewModel(int prototypeId)
        {
            IsOpenCommandBar = false;

            using (var db = new PrototypingContext())
            {
                PrototypeModel = db.Prototypes.Single(p => p.PrototypeId == prototypeId);
                Users = new ObservableCollection<UserPrototype>(db.Users.Where(u => u.PrototypeId == prototypeId));
            }
        }

        #region properties
        public ObservableCollection<UserPrototype> Users
        {
            get { return _users; }
            set { Set(ref _users, value); }
        }

        public Prototype PrototypeModel
        {
            get { return _prototypeModel; }
            set { Set(ref _prototypeModel, value); }
        }

        public UserPrototype SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    Set(ref _selectedItem, value);
                    ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsUserPage), value.UserPrototypeId);
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
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(PrototypesPage));
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
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddUserPage), PrototypeModel.PrototypeId);
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
        private void RemoveFunc()
        {
            using (var db = new PrototypingContext())
            {
                db.Prototypes.Remove(PrototypeModel);
                db.SaveChanges();
            }
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(PrototypesPage));
        }

        public ICommand ResultScreensCommand { get; private set; }



        #endregion
    }
}
