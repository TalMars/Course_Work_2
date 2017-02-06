﻿using CourseWork_2.HeatMap;
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
        private ObservableCollection<ReviewPrototypeModel> _screens;
        private bool _ringContentVisibility;
        private bool _selectVisibility;
        private Windows.UI.Xaml.Media.Imaging.WriteableBitmap _selectedScreen;

        public ResultScreensViewModel()
        {
        }

        #region properties
        public ObservableCollection<ReviewPrototypeModel> Screens
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

        public Windows.UI.Xaml.Media.Imaging.WriteableBitmap SelectedScreen
        {
            get { return _selectedScreen; }
            set { Set(ref _selectedScreen, value); }
        }
        #endregion

        public void GridView_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            Windows.UI.Xaml.Controls.GridView screensGridView = (Windows.UI.Xaml.Controls.GridView)sender;
            if (screensGridView.SelectedItem == null)
                return;

            SelectedScreen = ((ReviewPrototypeModel)screensGridView.SelectedItem).HeatMapScreen;
            SelectVisibility = true;

            screensGridView.SelectedItem = null;
        }
        
        public void SelectScreen_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            SelectedScreen = null;
            SelectVisibility = false;
        }
    }
}
