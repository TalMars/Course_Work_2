using CourseWork_2.DataBase.DBModels;
using CourseWork_2.Model;
using CourseWork_2.ViewModel;
using System.Collections.Generic;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
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
            ViewModel = new ResultRecordViewModel();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().ExitFullScreenMode();
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
