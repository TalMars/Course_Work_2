using CourseWork_2.DataBase.DBModels;
using CourseWork_2.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace CourseWork_2.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class SummaryEmotionsPage : Page
    {
        public SummaryEmotionsPage()
        {
            this.InitializeComponent();

            ViewModel = new SummaryEmotionsViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Prototype)
                ViewModel.LoadEmotionsForPrototype(((Prototype)e.Parameter).PrototypeId);
            if (e.Parameter is User)
                ViewModel.LoadEmotionsForUser(((User)e.Parameter).UserId);
            if (e.Parameter is Record)
                ViewModel.LoadEmotionsForRecord(((Record)e.Parameter).RecordId);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.UnregisterPressedEventHadler();
            ViewModel.UnregisterRequestEventHander();
        }

        public SummaryEmotionsViewModel ViewModel { get; private set; }
    }
}
