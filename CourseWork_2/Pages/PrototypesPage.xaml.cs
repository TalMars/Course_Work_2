using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
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
    public sealed partial class PrototypesPage : Page
    {
        public PrototypesPage()
        {
            ViewModel = new PrototypesViewModel();

            this.InitializeComponent();

            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
        }

        public PrototypesViewModel ViewModel { get; private set; }

        private void Item_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);

            flyoutBase.ShowAt(senderElement);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var prototype = (Prototype)(e.OriginalSource as FrameworkElement).DataContext;
            Frame.Navigate(typeof(AddPrototypePage), prototype.PrototypeId);
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var prototype = (Prototype)(e.OriginalSource as FrameworkElement).DataContext;
            await ViewModel.DeletePrototype(prototype);
        }
    }
}
