using CourseWork_2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CourseWork_2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReviewPrototypePage : Page
    {

        //#region PrototypeUriTest
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
        //#endregion

        //#region USerAgentStrings
        //private string chrome = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.94 Safari/537.36";
        //private string androidMobile = "Mozilla/5.0 (Linux; <Android Version>; <Build Tag etc.>) AppleWebKit/<WebKit Rev> (KHTML, like Gecko) Chrome/<Chrome Rev> Mobile Safari/<WebKit Rev>";
        //private string androidASUS = "Mozilla/5.0 (Linux; Android 6.0.1; ASUS_Z00ED Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.68 Mobile Safari/537.36";
        //private string firefox = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.8; rv:21.0) Gecko/20100101 Firefox/21.0";
        //private string def = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
        //private string androidTabled = "Mozilla/5.0 (Linux; Android 4.1.1; Nexus 7 Build/JRO03D) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Safari/535.19";
        //private string edge = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36 Edge/13.10586";
        //private string ios = "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1";
        //#endregion

        
        public ReviewPrototypePage()
        {
            this.InitializeComponent();

            var vm = new ReviewPrototypeViewModel();
            this.ViewModel = vm;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
           Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }

        public ReviewPrototypeViewModel ViewModel { get; private set; }
    }
}
