using CourseWork_2.DataBase.DBModels;
using CourseWork_2.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CourseWork_2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            this.InitializeComponent();
            ViewModel = new AddUserViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Prototype)
                ViewModel.LoadUser((Prototype)e.Parameter);
            if (e.Parameter is User)
                ViewModel.LoadUser((User)e.Parameter);
            if (e.Parameter is int)
                ViewModel.LoadUser((int)e.Parameter);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.UnregisterPressedEventHadler();
            ViewModel.UnregisterRequestEventHander();
        }

        public AddUserViewModel ViewModel { get; private set; }
    }
}
