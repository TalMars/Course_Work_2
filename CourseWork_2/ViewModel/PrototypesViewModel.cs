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
    public class PrototypesViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<Prototype> _prototypes;
        private Prototype _selectedItem;
        public PrototypesViewModel()
        {
            AddCommand = new Command(() => 
            {
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddPrototypePage));
            });

            using(var db = new PrototypingContext())
            {
                Prototypes = new ObservableCollection<Prototype>(db.Prototypes.ToList());
            }
        }

        #region properties
        public ObservableCollection<Prototype> Prototypes
        {
            get { return _prototypes; }
            set { _prototypes = value; OnPropertyChanged("Prototypes"); }
        }

        public Prototype SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                    ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(DetailsPrototypePage), value.PrototypeId);
                }
            }
        }
        #endregion

        #region events
        public ICommand AddCommand { get; private set; }
        #endregion
    }
}
