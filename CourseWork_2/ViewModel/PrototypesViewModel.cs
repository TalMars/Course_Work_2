using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Model;
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
        private ObservableCollection<PrototypeGroup> _prototypesGroup;
        private Prototype _selectedItem;
        private ICommand _addCommand;

        private static string[] semanticZoomNames = new string[] { "А", "Б", "В", "Г", "Д", "Е", "Ё",
                                                            "Ж", "З", "И", "Й", "К", "Л", "М",
                                                            "Н", "О", "П", "Р", "С", "Т", "У",
                                                            "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ",
                                                            "Ы", "Ь", "Э", "Ю", "Я", "#", "A",
                                                            "B", "C", "D", "E", "F", "G", "H",
                                                            "I", "J", "K", "L", "M", "N", "O",
                                                            "P", "Q", "R", "S", "T", "U", "V",
                                                            "W", "X", "Y", "Z"};

        public PrototypesViewModel()
        {
            using (var db = new PrototypingContext())
            {
                List<Prototype> prototypes = db.Prototypes.ToList();

                List<PrototypeGroup> protGroups = prototypes.GroupBy(p => p.Name[0], (key, items) => new PrototypeGroup()
                {
                    Name = key.ToString(),
                    Items = items.ToList(),
                    IsEnable = true
                }).ToList();
                string[] inDB = (from g in protGroups
                                 select g.Name).ToArray();
                List<PrototypeGroup> notInDB = (from n in semanticZoomNames
                                                where !inDB.Contains(n)
                                                select (new PrototypeGroup() { Name = n })).ToList();
                protGroups.AddRange(notInDB);
                protGroups = (from g in protGroups
                              orderby g.Name
                              select g).ToList();
                PrototypesGroup = new ObservableCollection<PrototypeGroup>(protGroups);
            }
        }

        #region properties
        public ObservableCollection<PrototypeGroup> PrototypesGroup
        {
            get { return _prototypesGroup; }
            set { Set(ref _prototypesGroup, value); }
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
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new Command(() => AddFunc()));
            }
        }

        private void AddFunc()
        {
            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(AddPrototypePage));
        }
        #endregion
    }
}
