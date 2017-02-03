using CourseWork_2.Extensions_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CourseWork_2.ViewModel
{
    public class ReviewPrototypeViewModel : NotifyPropertyChanged
    {
        private string uri7_2 = "https://marvelapp.com/2e6cj49";


        private bool isSplitViewPaneOpen;
        private string _sourceWebView = null;
        private Symbol _startStopIcon;
        private bool _ringActiveVisibility;
        private bool _contentVisibility;


        #region ChangeUSerAgent
        private string androidASUS = "Mozilla/5.0 (Linux; Android 6.0.1; ASUS_Z00ED Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.68 Mobile Safari/537.36";
        private string ios = "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1";

        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        const int URLMON_OPTION_USERAGENT = 0x10000001;
        public void ChangeUserAgent(string Agent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        }
        #endregion

        public ReviewPrototypeViewModel()
        {
            ChangeUserAgent(androidASUS);

            StartStopIcon = Symbol.Play;
            //StartStopButtonCommand = new Command(() =>
            //{
            //    if (isPlayIcon)
            //    {
            //        SourceWebView = uri7_2;
            //        IsSplitViewPaneOpen = false;
            //    }

            //    isPlayIcon = false;
            //});
        }
        //public ICommand StartStopButtonCommand
        //{
        //    get; private set;
        //}

        #region properties
        public string SourceWebView
        {
            get
            {
                return _sourceWebView;
            }
            set
            {
                _sourceWebView = value;
                OnPropertyChanged("SourceWebView");
            }
        }


        public bool IsSplitViewPaneOpen
        {
            get { return this.isSplitViewPaneOpen; }
            set { Set(ref this.isSplitViewPaneOpen, value); }
        }

        public Symbol StartStopIcon
        {
            get { return _startStopIcon; }
            set { _startStopIcon = value; OnPropertyChanged("StartStopIcon"); }
        }

        public bool RingActiveVisibility
        {
            get { return _ringActiveVisibility; }
            set { _ringActiveVisibility = value; OnPropertyChanged("RingActiveVisibility"); }
        }

        public bool ContentVisibility
        {
            get { return _contentVisibility; }
            set { _contentVisibility = value; OnPropertyChanged("ContentVisibility"); }
        }
        #endregion

        #region pane controls events
        public void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if (_startStopIcon.ToString().Equals("Play"))
            {
                SourceWebView = uri7_2;
                StartStopIcon = Symbol.Stop;
                IsSplitViewPaneOpen = false;
            }
        }
        #endregion

        #region WebView events
        public void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            RingActiveVisibility = true;
        }

        public async void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
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
            await sender.InvokeScriptAsync("eval", new string[] { docClickScript });

            RingActiveVisibility = false;
        }

        public void WebView_ScriptNotify(object sender, NotifyEventArgs e)
        {

        }
        #endregion
    }
}
