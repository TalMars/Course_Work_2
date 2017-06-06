using CourseWork_2.ViewModel;
using Windows.UI.Xaml.Controls;
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
