using CourseWork_2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace CourseWork_2.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class EmotionsPage : Page
    {
        public EmotionsPage()
        {
            this.InitializeComponent();

        }

        public EmotionsViewModel ViewModel { get; private set; }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = new EmotionsViewModel((int)e.Parameter);
            await ViewModel.LoadSubKey();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleaning();

            ViewModel.UnregisterPressedEventHadler();
            ViewModel.UnregisterRequestEventHander();
        }

    }
}
