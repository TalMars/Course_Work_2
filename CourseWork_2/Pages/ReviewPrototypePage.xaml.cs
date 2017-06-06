using CourseWork_2.ViewModel;
using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CourseWork_2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReviewPrototypePage : Page
    {
        #region PrototypeUriTest
        //private Uri uri1 = new Uri("https://share.framerjs.com/iz4erfou2mtv", UriKind.Absolute);
        //private Uri uri2 = new Uri("https://share.framerjs.com/fk6l598d276o", UriKind.Absolute);
        //private Uri uri3 = new Uri("https://share.framerjs.com/o2o8qjfx73gi", UriKind.Absolute);
        //private Uri uri4 = new Uri("https://share.framerjs.com/85ec7i6zjtaq", UriKind.Absolute);
        //private Uri uri5 = new Uri("https://share.framerjs.com/47o9uv5kemjf", UriKind.Absolute);
        //private Uri uri6 = new Uri("https://projects.invisionapp.com/share/979C6XGAU#/screens", UriKind.Absolute);
        //private Uri uri7 = new Uri("https://marvelapp.com/explore/977871/movie-app/", UriKind.Absolute);
        //private Uri uri7_2 = new Uri("https://marvelapp.com/2e6cj49", UriKind.Absolute);
        //private Uri uri8 = new Uri("https://app.atomic.io/d/2VK8j3nxowpZ", UriKind.Absolute);
        //private Uri uri9 = new Uri("https://app.atomic.io/d/2HbnogyIB1HD", UriKind.Absolute);
        //private Uri uri10 = new Uri("https://www.flinto.com/p/b7e37183", UriKind.Absolute);
        #endregion

        public ReviewPrototypePage()
        {
            this.InitializeComponent();
            ViewModel = new ReviewPrototypeViewModel();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
            await ViewModel.LoadData((int)e.Parameter);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleaning();
            ViewModel.UnregisterPressedEventHadler();
            ViewModel.UnregisterRequestEventHander();
        }

        public ReviewPrototypeViewModel ViewModel { get; private set; }
    }
}
