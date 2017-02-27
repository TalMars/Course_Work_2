using CourseWork_2.DataBase.DBModels;
using CourseWork_2.HeatMap;
using CourseWork_2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.ViewModel
{
    public class ResultScreensViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<RecordScreenPrototypeModel> _screens;
        private bool _ringContentVisibility;
        private bool _selectVisibility;
        private RecordScreenPrototypeModel _selectedItem;

        public ResultScreensViewModel()
        {
        }

        #region properties
        public ObservableCollection<RecordScreenPrototypeModel> Screens
        {
            get { return _screens; }
            set { Set(ref _screens, value); }
        }

        public bool RingContentVisibility
        {
            get { return _ringContentVisibility; }
            set { Set(ref _ringContentVisibility, value); }
        }

        public bool SelectVisibility
        {
            get { return _selectVisibility; }
            set { Set(ref _selectVisibility, value); }
        }

        public RecordScreenPrototypeModel SelectedItem
        {
            get { return _selectedItem; }
            set { Set(ref _selectedItem, value); SelectVisibility = true; }
        }
        #endregion
        
        public void SelectScreen_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            SelectedItem = null;
            SelectVisibility = false;
        }
    }
}
