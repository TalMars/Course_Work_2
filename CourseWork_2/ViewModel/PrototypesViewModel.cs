using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.ViewModel
{
    public class PrototypesViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<Prototype> _prototypes;
        public PrototypesViewModel()
        {
            using(var db = new PrototypingContext())
            {
                _prototypes = new ObservableCollection<Prototype>(db.Prototypes.ToList());
            }
        }

        public ObservableCollection<Prototype> Prototypes
        {
            get { return _prototypes; }
            set { _prototypes = value; OnPropertyChanged("Prototypes"); }
        }
    }
}
