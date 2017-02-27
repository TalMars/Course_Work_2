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
using Windows.Graphics.Imaging;
using Windows.Storage;
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
            ViewModel.RingContentVisibility = true;
            ViewModel.Screens = await HeatingScreens((List<RecordScreenPrototypeModel>)e.Parameter);
            ViewModel.RingContentVisibility = false;
        }

        public ResultScreensViewModel ViewModel
        {
            get { return vm; }
            private set { vm = value; }
        }

        private async Task<ObservableCollection<RecordScreenPrototypeModel>> HeatingScreens(List<RecordScreenPrototypeModel> screens)
        {
            ObservableCollection<RecordScreenPrototypeModel> result = new ObservableCollection<RecordScreenPrototypeModel>();
            using (var db = new PrototypingContext())
            {
                RecordPrototype record = db.RecordsPrototype.Last();
                foreach (RecordScreenPrototypeModel screen in screens)
                {
                    screen.HeatMapScreen = await HeatMapFunctions.CreateProcessHeatMap(screen.OriginalScreen, screen.ListPoints);

                    UserPrototype user = db.Users.Single(u => u.UserPrototypeId == record.UserPrototypeId);
                    await db.Entry(user)
                            .Reference(u => u.Prototype)
                            .LoadAsync();

                    string prototypeName = user.Prototype.Name + "_" + user.PrototypeId;
                    string userName = user.Name + "_" + user.UserPrototypeId;
                    string originalPath = await SaveImageInStorage(screen.OriginalScreen, false, prototypeName, userName);
                    string heatMapPath = await SaveImageInStorage(screen.HeatMapScreen, true, prototypeName, userName);

                    RecordsScreen rScreen = new RecordsScreen()
                    {
                        RecordPrototypeId = record.RecordPrototypeId,
                        Points = screen.ListPoints,
                        UriPage = screen.UriPage,
                        PathToOriginalScreen = originalPath,
                        PathToHeatMapScreen = heatMapPath
                    };
                    db.RecordsScreens.Add(rScreen);
                    result.Add(screen);
                }
                db.SaveChanges();
            }
            return result;
        }

        private async Task<string> SaveImageInStorage(WriteableBitmap image, bool isHeat, string prototypeName, string userName)
        {
            StorageFolder prototypeFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(prototypeName, CreationCollisionOption.OpenIfExists); //PrototypeName + Id
            StorageFolder userFolder = await prototypeFolder.CreateFolderAsync(userName, CreationCollisionOption.OpenIfExists); //UserName + Id
            StorageFolder screensFolder = await userFolder.CreateFolderAsync("Screens", CreationCollisionOption.OpenIfExists);
            StorageFile file = await screensFolder.CreateFileAsync("Screen" + (isHeat ? "_heat" : "") + " (1).jpg", CreationCollisionOption.GenerateUniqueName); //Screen.jpg = originalScreen, Screen + _heat + .jpg = heatmap screen

            using (var stream = await file.OpenStreamForWriteAsync())
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream.AsRandomAccessStream());
                var pixelStream = image.PixelBuffer.AsStream();
                byte[] pixels = new byte[image.PixelBuffer.Length];

                await pixelStream.ReadAsync(pixels, 0, pixels.Length);

                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)image.PixelWidth, (uint)image.PixelHeight, 96, 96, pixels);

                await encoder.FlushAsync();
            }

            return file.Path;
        }
    }
}
