using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.HeatMap;
using CourseWork_2.Model;
using CourseWork_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CourseWork_2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultScreensPage : Page
    {
        private ResultScreensViewModel vm;

        public ResultScreensPage()
        {
            this.InitializeComponent();

            vm = new ResultScreensViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            ObservableCollection<ReviewPrototypeModel> screensPoints = (ObservableCollection<ReviewPrototypeModel>)e.Parameter;
            ViewModel.RingContentVisibility = true;
            ViewModel.Screens = await HeatingScreens(screensPoints);
            ViewModel.RingContentVisibility = false;
        }

        public ResultScreensViewModel ViewModel
        {
            get { return vm; }
            private set { vm = value; }
        }

        private async Task<ObservableCollection<RecordsScreen>> HeatingScreens(ObservableCollection<ReviewPrototypeModel> screenPoints)
        {
            ObservableCollection<RecordsScreen> result = new ObservableCollection<RecordsScreen>();
            using (var db = new PrototypingContext())
            {
                int recordId = db.RecordsPrototype.Last().RecordPrototypeId;
                foreach (ReviewPrototypeModel picturePoints in screenPoints)
                {
                    picturePoints.HeatMapScreen = await HeatMapFunctions.CreateProcessHeatMap(picturePoints.ScreenPage, picturePoints.ListPoints);

                    RecordsScreen rScreen = new RecordsScreen()
                    {
                        RecordPrototypeId = recordId,
                        Points = picturePoints.ListPoints,
                        UriPage = picturePoints.UriPage,
                        HeightImage = picturePoints.HeightImage,
                        WidthImage = picturePoints.WidthImage,
                        OriginalScreen = HeatMapFunctions.AsByteArray(picturePoints.ScreenPage),
                        HeatMapScreen = HeatMapFunctions.AsByteArray(picturePoints.HeatMapScreen)
                    };
                    db.RecordsScreens.Add(rScreen);
                    result.Add(rScreen);
                }
                db.SaveChanges();
            }
            return result;
        }
    }
}
