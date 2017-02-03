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

        //#region ChangeUSerAgent
        //[DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        //private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        //const int URLMON_OPTION_USERAGENT = 0x10000001;
        //public void ChangeUserAgent(string Agent)
        //{
        //    UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        //}
        //#endregion

        public ReviewPrototypePage()
        {
            this.InitializeComponent();

            var vm = new ReviewPrototypeViewModel();
            this.ViewModel = vm;
            

            // add entry animations
            //var transitions = new TransitionCollection { };
            //var transition = new NavigationThemeTransition { };
            //transitions.Add(transition);
            //this.Frame.ContentTransitions = transitions;
        }

        public ReviewPrototypeViewModel ViewModel { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //ChangeUserAgent(androidASUS);

            //PrototypeView.Settings.IsIndexedDBEnabled = true;
            //PrototypeView.Settings.IsJavaScriptEnabled = true;
            //PrototypeView.NavigationStarting += PrototypeView_NavigationStarting;
            //PrototypeView.NavigationCompleted += PrototypeView_NavigationCompleted;
            //PrototypeView.ScriptNotify += PrototypeView_ScriptNotify;
            
            //PrototypeView.Navigate(uri7_2);
        }

        //private void PrototypeView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        //{
        //    PrototypeView.Visibility = Visibility.Collapsed;
        //    PrototypeRing.IsActive = true;
        //    PrototypeRing.Visibility = Visibility.Visible;
        //}

        private async void PrototypeView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            string docClickScript = @"if (document.addEventListener) {" +
                    "document.addEventListener(\"click\", PageClicked, false);" +
                "} else {" +
                    "document.attachEvent('onclick', PageClicked);" +
                "}  " +
                "function PageClicked(event){" +
                    "var pointX = event.clientX;" +
                    "var pointY = event.clientY;" +
                    " window.external.notify('tapClick:' + pointX + ':' + pointY);" +
                 "}";
            //await PrototypeView.InvokeScriptAsync("eval", new string[] { docClickScript });

            //string SetBodyOverFlowHiddenString = @"function SetBodyOverFlowHidden()
            //{
            //    document.body.style.overflow = 'hidden';
            //    return 'Set Style to hidden';
            //}

            //// now call the function!

            //SetBodyOverFlowHidden();";

            //string returnStr = await PrototypeView.InvokeScriptAsync("eval", new string[] { SetBodyOverFlowHiddenString });
            
            //PrototypeRing.Visibility = Visibility.Collapsed;
            //PrototypeRing.IsActive = false;
            //PrototypeView.Visibility = Visibility.Visible;

            //string userAgentDetect = "document.head.innerHTML += '<!-- ' + navigator.userAgent + '____ ' + navigator.platform + ' -->'";
            //string scale = "document.getElementsByName('viewport')[0].setAttribute('content', 'width=device-width, height=device-height, initial-scale=1.5, maximum-scale=1, user-scalable=no, shrink-to-fit=no');";
            //string zoom = "document.body.style.zoom = '150%';";
            //if (args.IsSuccess)
            //{
            //    await PrototypeView.InvokeScriptAsync("eval", new string[] { userAgentDetect });
            //    await PrototypeView.InvokeScriptAsync("eval", new string[] { scale });
            //    string html = await PrototypeView.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
            //    System.Diagnostics.Debug.WriteLine(html);
            //}
        }
    }
}
