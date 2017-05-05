using CourseWork_2.DataBase.DBModels;
using CourseWork_2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
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
    public sealed partial class DetailsPrototypePage : Page
    {
        public DetailsPrototypePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = new DetailsPrototypeViewModel((int)e.Parameter);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.UnregisterPressedEventHadler();
            ViewModel.UnregisterRequestEventHander();
        }

        public DetailsPrototypeViewModel ViewModel { get; private set; }

        private void Item_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);

            flyoutBase.ShowAt(senderElement);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)(e.OriginalSource as FrameworkElement).DataContext;
            Frame.Navigate(typeof(AddUserPage), user.UserId);
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var user = (User)(e.OriginalSource as FrameworkElement).DataContext;
            await ViewModel.DeleteUser(user);
        }
    }
}
