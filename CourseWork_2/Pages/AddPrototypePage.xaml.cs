using CourseWork_2.DataBase.DBModels;
using CourseWork_2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CourseWork_2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPrototypePage : Page
    {
        public AddPrototypePage()
        {
            this.InitializeComponent();
            ViewModel = new AddPrototypeViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
                LoadState();
            else
            {
                if (e.Parameter != null)
                    ViewModel.LoadPrototype((Prototype)e.Parameter);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.UnregisterPressedEventHadler();
            ViewModel.UnregisterRequestEventHander();
        }

        internal void SaveState()
        {
            ApplicationData.Current.RoamingSettings.Values["PrototypeName"] = ViewModel.NameText;
            ApplicationData.Current.RoamingSettings.Values["PrototypeUrl"] = ViewModel.UrlText;
            ApplicationData.Current.RoamingSettings.Values["PrototypeDescription"] = ViewModel.DescriptionText;
        }

        internal void LoadState()
        {
            var rs = ApplicationData.Current.RoamingSettings;
            if (rs.Values["PrototypeName"] != null)
                ViewModel.NameText = rs.Values["PrototypeName"].ToString();
            if (rs.Values["PrototypeUrl"] != null)
                ViewModel.UrlText = rs.Values["PrototypeUrl"].ToString();
            if (rs.Values["PrototypeDescription"] != null)
                ViewModel.DescriptionText = rs.Values["PrototypeDescription"].ToString();
        }

        public AddPrototypeViewModel ViewModel { get; private set; }

    }
}
