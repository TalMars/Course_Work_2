using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.HeatMap;
using CourseWork_2.Model;
using CourseWork_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CourseWork_2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultRecordPage : Page
    {
        public ResultRecordPage()
        {
            this.InitializeComponent();

            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().ExitFullScreenMode();
            ViewModel = new ResultRecordViewModel();

            if (e.Parameter is Prototype)
            {
                await ViewModel.HeatingAllRecordScreens((Prototype)e.Parameter);
            }
            if (e.Parameter is User)
            {
                await ViewModel.HeatingAllRecordScreens((User)e.Parameter);
            }
            if (e.Parameter is Record)
            {
                await ViewModel.GetRecordScreens((Record)e.Parameter);
            }
            if (e.Parameter is List<RecordScreenModel>)
            {
                await ViewModel.HeatSaveScreens((List<RecordScreenModel>)e.Parameter); //ObjectDisposeException when list empty!!!
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (ViewModel.RecordVideo != null)
            {
                ViewModel.RecordVideo.MediaPlayer.Pause();
                ViewModel.RecordVideo.MediaPlayer.Dispose();
            }

            ViewModel.UnregisterPressedEventHadler();
            ViewModel.UnregisterRequestEventHander();
        }

        public ResultRecordViewModel ViewModel { get; set; }
    }
}
