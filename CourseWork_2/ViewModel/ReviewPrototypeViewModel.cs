using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.HeatMap;
using CourseWork_2.Model;
using CourseWork_2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage.Streams;

namespace CourseWork_2.ViewModel
{
    public class ReviewPrototypeViewModel : NotifyPropertyChanged
    {
        private bool isSplitViewPaneOpen;
        private string _sourceWebView = null;
        private bool _isOnStart;
        private bool _ringContentVisibility;
        private ICommand _startStopCommand;
        private ICommand _cancelCommand;
        private int userId;
        private string recordId;
        private bool isLastUri;

        private Windows.UI.Xaml.DispatcherTimer timer;
        private string _timerText;
        private int timerSeconds;

        private List<RecordScreenPrototypeModel> _screens;

        #region ChangeUSerAgent
        private string androidASUS = "Mozilla/5.0 (Linux; Android 6.0.1; ASUS_Z00ED Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.68 Mobile Safari/537.36";

        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        const int URLMON_OPTION_USERAGENT = 0x10000001;
        public void ChangeUserAgent(string Agent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        }
        #endregion

        public ReviewPrototypeViewModel(int _userId)
        {
            ChangeUserAgent(androidASUS);

            _screens = new List<RecordScreenPrototypeModel>();
            IsOnStart = true;
            isLastUri = false;
            userId = _userId;

            using (var db = new PrototypingContext())
            {
                UserPrototype user = db.Users.Single(u => u.UserPrototypeId == userId);
                db.Entry(user).Reference(u => u.Prototype).Load();
                SourceWebView = user.Prototype.Url;
            }
        }

        #region properties
        public string SourceWebView
        {
            get { return _sourceWebView; }
            set { Set(ref _sourceWebView, value); }
        }

        public bool IsSplitViewPaneOpen
        {
            get { return isSplitViewPaneOpen; }
            set { Set(ref isSplitViewPaneOpen, value); }
        }

        public bool IsOnStart
        {
            get { return _isOnStart; }
            set { Set(ref _isOnStart, value); }
        }

        public bool RingContentVisibility
        {
            get { return _ringContentVisibility; }
            set { Set(ref _ringContentVisibility, value); }
        }

        public string TimerText
        {
            get { return _timerText; }
            set { Set(ref _timerText, value); }
        }
        #endregion

        #region pane controls events
        public ICommand StartStopCommand
        {
            get
            {
                return _startStopCommand ?? (_startStopCommand = new Command(() => StartStopFunc()));
            }
        }

        private void StartStopFunc()
        {
            if (_isOnStart)
            {
                TimerInit();
                IsOnStart = false;
                IsSplitViewPaneOpen = false;

                using (var db = new PrototypingContext())
                {
                    db.RecordsPrototype.Add(new RecordPrototype() { CreatedDate = DateTime.Now, UserPrototypeId = userId });
                    db.SaveChanges();
                    recordId = db.RecordsPrototype.Last().RecordPrototypeId.ToString();
                }
            }
            else
            {
                timer.Stop();
                ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).Navigate(typeof(ResultScreensPage), _screens);
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new Command(() => CancelFunc()));
            }
        }

        private void CancelFunc()
        {
            if(recordId != null)
            {
                using (var db = new PrototypingContext())
                {
                    db.RecordsPrototype.Remove(db.RecordsPrototype.Single(r => r.RecordPrototypeId == int.Parse(recordId)));
                    db.SaveChanges();
                }
            }

            ((Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content).GoBack();
        }
        #endregion

        #region Timer Events
        private void TimerInit()
        {
            timer = new Windows.UI.Xaml.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            string hours = (timerSeconds / 3600).ToString();
            string minutes = ((timerSeconds % 3600) / 60).ToString();
            string seconds = (timerSeconds % 60).ToString();

            TimerText = hours + ":" + minutes + ":" + seconds;
            timerSeconds++;
        }
        #endregion

        #region WebView events
        public void WebView_NavigationStarting(Windows.UI.Xaml.Controls.WebView sender, Windows.UI.Xaml.Controls.WebViewNavigationStartingEventArgs args)
        {
            RingContentVisibility = true;
        }

        public async void WebView_NavigationCompleted(Windows.UI.Xaml.Controls.WebView sender, Windows.UI.Xaml.Controls.WebViewNavigationCompletedEventArgs args)
        {
            string docClickScript = @"if (document.addEventListener) {" +
                    "document.addEventListener(\"click\", PageClicked, false);" +
                "} else {" +
                    "document.attachEvent('onclick', PageClicked);" +
                "}  " +
                "function PageClicked(event){" +
                    "var pointX = event.clientX;" +
                    "var pointY = event.clientY;" +
                    " window.external.notify('tap:' + pointX + ':' + pointY);" +
                 "}";
            await sender.InvokeScriptAsync("eval", new string[] { docClickScript }); //set event 'click' on page

            RingContentVisibility = false;
        }

        public async void WebView_ScriptNotify(object sender, Windows.UI.Xaml.Controls.NotifyEventArgs e)
        {
            if (e.Value.Contains("tap") && !IsOnStart)
            {
                Windows.UI.Xaml.Controls.WebView webView = (Windows.UI.Xaml.Controls.WebView)sender;

                float x;
                float y;
                string[] arr = e.Value.Replace('.', ',').Split(new char[] { ':' });

                if (!float.TryParse(arr[1], out x))
                {
                    System.Diagnostics.Debug.WriteLine("ErrorX");
                }

                if (!float.TryParse(arr[2], out y))
                {
                    System.Diagnostics.Debug.WriteLine("ErrorY");
                }

                int iX = (int)Math.Round(x);
                int iY = (int)Math.Round(y);

                System.Diagnostics.Debug.WriteLine(e.CallingUri.AbsoluteUri);
                System.Diagnostics.Debug.WriteLine(iX + "   " + iY);

                HeatPoint hp = new HeatPoint(iX, iY);

                int indexUri;
                bool isFindIndex = false;
                for (indexUri = 0; !isFindIndex && indexUri < _screens.Count; indexUri++)
                {
                    if (_screens[indexUri].UriPage.Equals(webView.Source.AbsoluteUri))
                    {
                        isFindIndex = true;
                    }
                }

                if (isFindIndex)
                {
                    _screens[indexUri - 1].ListPoints.Add(hp);
                }
                else
                {
                    if (isLastUri)
                    {
                        isLastUri = false;
                        _screens[indexUri - 1].ListPoints.Add(hp);
                    }
                    else
                    {
                        isLastUri = true;
                        //screenshot
                        await DoCaptureWebView(webView, hp);
                    }
                }
            }
        }

        private async Task<bool> DoCaptureWebView(Windows.UI.Xaml.Controls.WebView webview, HeatPoint hp)
        {
            bool isOk = true;

            RingContentVisibility = true;

            #region comments maybe help
            //string scrollHeight = await webview.InvokeScriptAsync("eval", new string[] { "screen.height.toString();" });
            //string scrollWidth = await webview.InvokeScriptAsync("eval", new string[] { "screen.width.toString();" });
            //string scrollHeight = await webview.InvokeScriptAsync("eval", new string[] { "document.body.scrollHeight.toString();" });
            //string scrollWidth = await webview.InvokeScriptAsync("eval", new string[] { "document.body.scrollWidth.toString();" });
            //float height;
            //float width;
            //if (!float.TryParse(scrollWidth, out width))
            //{
            //    System.Diagnostics.Debug.WriteLine("ErrorWidth");
            //    isOk = false;
            //}
            //if (!float.TryParse(scrollHeight, out height))
            //{
            //    System.Diagnostics.Debug.WriteLine("ErrorHeight");
            //    isOk = false;
            //}

            //int screenHeight = (int)height;
            //int screenWidth = (int)width;
            #endregion

            int screenHeight = (int)webview.ActualHeight;
            int screenWidth = (int)webview.ActualWidth;

            InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream();
            await webview.CapturePreviewToStreamAsync(ms);

            Windows.UI.Xaml.Media.Imaging.WriteableBitmap wb = await HeatMapFunctions.Resize(screenWidth, screenHeight, ms);

            _screens.Add(new RecordScreenPrototypeModel(webview.Source.AbsoluteUri, wb));
            _screens[_screens.Count - 1].ListPoints.Add(hp);

            RingContentVisibility = false;

            return isOk;
        }

        #endregion
    }
}
