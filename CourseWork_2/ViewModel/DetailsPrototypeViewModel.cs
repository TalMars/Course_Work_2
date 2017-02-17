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
    public class DetailsPrototypeViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<UserPrototype> _users;
        private Prototype _prototypeModel;
        private UserPrototype _selectedItem;

        public DetailsPrototypeViewModel(int prototypeId)
        {
            GoBackCommand = new Command(() => 
            {
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(PrototypesPage));
            });

            EditCommand = new Command(() => 
            {
                //((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddPrototypePage), prototype);
            });

            AddCommand = new Command(() =>
            {
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddUserPage), prototypeId);
            });

            ResultScreensCommand = new Command(() => 
            {
                //((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ResultScreensPage), prototype);
            });

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
            set { _users = value; OnPropertyChanged("Users"); }
        }

        public Prototype PrototypeModel
        {
            get { return _prototypeModel; }
            set { _prototypeModel = value; OnPropertyChanged("PrototypeModel"); }
        }

        public UserPrototype SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if(_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                    ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsUserPage), value);
                }
            }
        }
        #endregion

        #region events
        public ICommand GoBackCommand { get; private set; }
        
        public ICommand EditCommand { get; private set; }

        public ICommand AddCommand { get; private set; }

        public ICommand ResultScreensCommand { get; private set; }
        #endregion
    }
}
