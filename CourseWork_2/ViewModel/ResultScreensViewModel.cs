using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using CourseWork_2.HeatMap;
using CourseWork_2.Model;
using CourseWork_2.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Graphics.Imaging;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace CourseWork_2.ViewModel
{
    public class ResultScreensViewModel : NotifyPropertyChanged
    {
        private bool _ringContentVisibility;
        private bool _selectVisibility;

        private ObservableCollection<RecordScreenPrototypeModel> _screens;
        private ObservableCollection<RecordPrototype> _records;
        private RecordScreenPrototypeModel _selectedItem;
        private RecordPrototype _selectedRecord;
        private RecordPrototype RecordModel;
        private Windows.UI.Xaml.Controls.MediaPlayerElement _recordVideo;
        private bool _videoIconVisibility;
        private bool _videoGridVisibility;
        private Windows.UI.Xaml.Controls.Symbol _showScreenVideoIcon;

        private List<StorageFile> videoList;

        private EventHandler<Windows.UI.Core.BackRequestedEventArgs> requestHandler;
        private EventHandler<Windows.Phone.UI.Input.BackPressedEventArgs> pressedHandler;
        private int prototypeId;
        private int userId;

        private ICommand _doneCommand;
        private ICommand _showVideoCommand;
        private ICommand _doubleTapCommand;

        public ResultScreensViewModel()
        {
            ShowScreenVideoIcon = Windows.UI.Xaml.Controls.Symbol.Video;
            prototypeId = -1;
            userId = -1;

            //GoBack Navigation
            RegisterGoBackEventHandlers();
        }

        #region back event
        private void RegisterGoBackEventHandlers()
        {
            requestHandler = (o, ea) =>
            {
                ea.Handled = true;
                if (!_selectVisibility)
                {
                    GoBackFunc();
                }
                else
                {
                    SelectedItem = null;
                    SelectVisibility = false;
                }
            };
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += requestHandler;

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                pressedHandler = (o, ea) =>
                {
                    ea.Handled = true;
                    if (!_selectVisibility)
                    {
                        GoBackFunc();
                    }
                    else
                    {
                        SelectedItem = null;
                        SelectVisibility = false;
                    }
                };
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += pressedHandler;
            }
        }

        public void UnregisterRequestEventHander()
        {
            if (requestHandler != null)
            {
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested -= requestHandler;
            }
        }

        public void UnregisterPressedEventHadler()
        {
            if (pressedHandler != null)
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed -= pressedHandler;
            }
        }
        #endregion

        #region properties
        public ObservableCollection<RecordScreenPrototypeModel> Screens
        {
            get { return _screens; }
            set { Set(ref _screens, value); }
        }

        public ObservableCollection<RecordPrototype> Records
        {
            get { return _records; }
            set { Set(ref _records, value); }
        }

        public RecordPrototype SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                Set(ref _selectedRecord, value);
                StorageFile video = (from v in videoList
                                     where v.Path.Equals(_selectedRecord.PathToVideo)
                                     select v).ToList()[0];
                if (RecordVideo == null)
                {
                    Windows.UI.Xaml.Controls.MediaPlayerElement player = new Windows.UI.Xaml.Controls.MediaPlayerElement();
                    player.AreTransportControlsEnabled = true;
                    RecordVideo = player;
                }
                RecordVideo.Source = MediaSource.CreateFromStorageFile(video);
            }
        }

        public bool RingContentVisibility
        {
            get { return _ringContentVisibility; }
            set { Set(ref _ringContentVisibility, value); }
        }

        public bool SelectVisibility
        {
            get { return _selectVisibility; }
            set { Set(ref _selectVisibility, value); }
        }

        public RecordScreenPrototypeModel SelectedItem
        {
            get { return _selectedItem; }
            set { Set(ref _selectedItem, value); SelectVisibility = true; }
        }

        public Windows.UI.Xaml.Controls.MediaPlayerElement RecordVideo
        {
            get { return _recordVideo; }
            set { Set(ref _recordVideo, value); }
        }

        public bool VideoIconVisibility
        {
            get { return _videoIconVisibility; }
            set { Set(ref _videoIconVisibility, value); }
        }

        public bool VideoGridVisibility
        {
            get { return _videoGridVisibility; }
            set { Set(ref _videoGridVisibility, value); }
        }

        public Windows.UI.Xaml.Controls.Symbol ShowScreenVideoIcon
        {
            get { return _showScreenVideoIcon; }
            set { Set(ref _showScreenVideoIcon, value); }
        }
        #endregion

        #region events
        public ICommand DoubleTapCommand
        {
            get
            {
                return _doubleTapCommand ?? (_doubleTapCommand = new Command(() => DoubleTapFunc()));
            }
        }

        private void DoubleTapFunc()
        {
            SelectedItem = null;
            SelectVisibility = false;
        }

        public ICommand DoneCommand
        {
            get
            {
                return _doneCommand ?? (_doneCommand = new Command(() => GoBackFunc()));
            }
        }

        private void GoBackFunc()
        {
            Windows.UI.Xaml.Controls.Frame frame = (Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content;
            frame.BackStack.Clear();
            if (prototypeId >= 0)
                frame.Navigate(typeof(DetailsPrototypePage), prototypeId);
            if (userId >= 0)
                frame.Navigate(typeof(DetailsUserPage), userId);
            if (RecordModel != null)
                frame.Navigate(typeof(DetailsUserPage), RecordModel.UserPrototypeId);
        }

        public ICommand ShowVideoCommand
        {
            get { return _showVideoCommand ?? (_showVideoCommand = new Command(() => ShowVideFunc())); }
        }

        private void ShowVideFunc()
        {
            if (_videoGridVisibility && RecordVideo != null)
                RecordVideo.MediaPlayer.Pause();

            ShowScreenVideoIcon = _videoGridVisibility ? Windows.UI.Xaml.Controls.Symbol.Video : Windows.UI.Xaml.Controls.Symbol.BrowsePhotos;
            VideoGridVisibility = !_videoGridVisibility;
        }
        #endregion

        #region from RecordPage
        public async Task HeatSaveScreens(List<RecordScreenPrototypeModel> reviewModels)
        {
            RingContentVisibility = true;
            using (var db = new PrototypingContext())
            {
                RecordModel = db.RecordsPrototype.Last();
                if (!string.IsNullOrEmpty(RecordModel.PathToVideo))
                {
                    StorageFile videoFile = await StorageFile.GetFileFromPathAsync(RecordModel.PathToVideo);
                    await Task.Delay(1000);
                    Windows.UI.Xaml.Controls.MediaPlayerElement player = new Windows.UI.Xaml.Controls.MediaPlayerElement();
                    player.AreTransportControlsEnabled = true;
                    player.Source = MediaSource.CreateFromStorageFile(videoFile);
                    RecordVideo = player;
                    //RecordVideo = MediaSource.CreateFromStorageFile(videoFile);
                    VideoIconVisibility = true;
                }
                else
                {
                    VideoIconVisibility = false;
                }
            }
            Screens = await HeatingScreens(reviewModels);
            RingContentVisibility = false;
        }

        private async Task<ObservableCollection<RecordScreenPrototypeModel>> HeatingScreens(List<RecordScreenPrototypeModel> screens)
        {
            ObservableCollection<RecordScreenPrototypeModel> result = new ObservableCollection<RecordScreenPrototypeModel>();
            using (var db = new PrototypingContext())
            {
                UserPrototype user = db.Users.Single(u => u.UserPrototypeId == RecordModel.UserPrototypeId);
                await db.Entry(user)
                        .Reference(u => u.Prototype)
                        .LoadAsync();

                string prototypeName = user.Prototype.Name + "_" + user.PrototypeId;
                string userName = user.Name + "_" + user.UserPrototypeId;
                string recordName = "Record_" + RecordModel.RecordPrototypeId;

                StorageFolder prototypeFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(prototypeName, CreationCollisionOption.OpenIfExists); //PrototypeName + Id
                StorageFolder userFolder = await prototypeFolder.CreateFolderAsync(userName, CreationCollisionOption.OpenIfExists); //UserName + Id
                StorageFolder recordFolder = await userFolder.CreateFolderAsync(recordName, CreationCollisionOption.OpenIfExists);

                foreach (RecordScreenPrototypeModel screen in screens)
                {
                    screen.HeatMapScreen = await HeatMapFunctions.CreateProcessHeatMap(screen.OriginalScreen, screen.ListPoints);
                    result.Add(screen);

                    string[] screenPaths = await SaveImagesInStorage(screen.OriginalScreen, screen.HeatMapScreen, recordFolder); //saving images in prototype -> user -> record path

                    RecordsScreen rScreen = new RecordsScreen()
                    {
                        RecordPrototypeId = RecordModel.RecordPrototypeId,
                        Points = screen.ListPoints,
                        UriPage = screen.UriPage,
                        PathToOriginalScreen = screenPaths[0],
                        PathToHeatMapScreen = screenPaths[1]
                    };
                    db.RecordsScreens.Add(rScreen);
                    db.SaveChanges();
                }
            }
            return result;
        }

        private async Task<string[]> SaveImagesInStorage(WriteableBitmap imageOriginal, WriteableBitmap imageHeat, StorageFolder recordFolder)
        {
            //Saving Original ImageScreen
            StorageFile fileOriginal = await recordFolder.CreateFileAsync("Screen (1).jpg", CreationCollisionOption.GenerateUniqueName); //Screen.jpg = originalScreen, Screen + _heat + .jpg = heatmap screen
            using (var stream = await fileOriginal.OpenStreamForWriteAsync())
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream.AsRandomAccessStream());
                var pixelStream = imageOriginal.PixelBuffer.AsStream();
                byte[] pixels = new byte[imageOriginal.PixelBuffer.Length];

                await pixelStream.ReadAsync(pixels, 0, pixels.Length);

                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)imageOriginal.PixelWidth, (uint)imageOriginal.PixelHeight, 96, 96, pixels);

                await encoder.FlushAsync();
            }

            //Saving HeatMap ImageScreen
            StorageFile fileHeat = await recordFolder.CreateFileAsync("Screen_heat (1).jpg", CreationCollisionOption.GenerateUniqueName); //Screen.jpg = originalScreen, Screen + _heat + .jpg = heatmap screen
            using (var stream = await fileHeat.OpenStreamForWriteAsync())
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream.AsRandomAccessStream());
                var pixelStream = imageHeat.PixelBuffer.AsStream();
                byte[] pixels = new byte[imageHeat.PixelBuffer.Length];

                await pixelStream.ReadAsync(pixels, 0, pixels.Length);

                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)imageHeat.PixelWidth, (uint)imageHeat.PixelHeight, 96, 96, pixels);

                await encoder.FlushAsync();
            }

            //return Original And Heat screens paths
            return new string[] { fileOriginal.Path, fileHeat.Path };
        }
        #endregion

        #region select all screens
        public async Task HeatingAllRecordScreens(Prototype prototype)
        {
            prototypeId = prototype.PrototypeId;
            RingContentVisibility = true;
            using (var db = new PrototypingContext())
            {
                List<RecordsScreen> allScreen = db.RecordsScreens
                                                .Include(r => r.RecordPrototype)
                                                    .ThenInclude(rp => rp.UserPrototype)
                                                .Where(rs => rs.RecordPrototype.UserPrototype.PrototypeId == prototype.PrototypeId)
                                                .OrderByDescending(rs => rs.UriPage)
                                                .ToList();
                Screens = await HeatingRecordScreens(allScreen);

                List<RecordPrototype> records = db.RecordsPrototype
                            .Include(rp => rp.UserPrototype)
                            .Where(rp => rp.UserPrototype.PrototypeId == prototype.PrototypeId)
                            .OrderBy(rp => rp.CreatedDate)
                            .ToList();
                Records = new ObservableCollection<RecordPrototype>(records);
                if (records.Count != 0)
                {
                    string[] pathsToFiles = (from r in records
                                             select r.PathToVideo).ToArray();
                    videoList = new List<StorageFile>();
                    await LoadigVideoFiles(pathsToFiles);
                    SelectedRecord = Records.First();
                    VideoIconVisibility = true;
                }
            }
            RingContentVisibility = false;
        }

        private async Task LoadigVideoFiles(string[] pathsToFiles)
        {
            foreach (string path in pathsToFiles)
            {
                StorageFile video = await StorageFile.GetFileFromPathAsync(path);
                videoList.Add(video);
            }
        }

        public async Task HeatingAllRecordScreens(UserPrototype user)
        {
            userId = user.UserPrototypeId;
            RingContentVisibility = true;
            using (var db = new PrototypingContext())
            {
                List<RecordsScreen> allScreen = db.RecordsScreens
                                                  .Include(rs => rs.RecordPrototype)
                                                  .Where(rs => rs.RecordPrototype.UserPrototypeId == user.UserPrototypeId)
                                                  .OrderByDescending(rs => rs.UriPage)
                                                  .ToList();
                Screens = await HeatingRecordScreens(allScreen);

                List<RecordPrototype> records = db.RecordsPrototype
                            .Where(rp => rp.UserPrototype.UserPrototypeId == user.UserPrototypeId)
                            .OrderBy(rp => rp.CreatedDate)
                            .ToList();
                Records = new ObservableCollection<RecordPrototype>(records);
                if (records.Count != 0)
                {
                    string[] pathsToFiles = (from r in records
                                             select r.PathToVideo).ToArray();
                    videoList = new List<StorageFile>();
                    await LoadigVideoFiles(pathsToFiles);
                    SelectedRecord = Records.First();
                    VideoIconVisibility = true;
                }
            }
            RingContentVisibility = false;
        }

        private async Task<ObservableCollection<RecordScreenPrototypeModel>> HeatingRecordScreens(List<RecordsScreen> allScreen)
        {
            ObservableCollection<RecordScreenPrototypeModel> result = new ObservableCollection<RecordScreenPrototypeModel>();
            while (allScreen.Count != 0)
            {
                List<HeatPoint> points = allScreen.FindAll(s => s.UriPage.Equals(allScreen[0].UriPage)).SelectMany(s => s.Points).ToList();
                WriteableBitmap original = await HeatMapFunctions.AsWrBitmapFromFile(allScreen[0].PathToOriginalScreen);
                WriteableBitmap heatMap = await HeatMapFunctions.CreateProcessHeatMap(original, points);
                result.Add(new RecordScreenPrototypeModel()
                {
                    UriPage = allScreen[0].UriPage,
                    OriginalScreen = original,
                    HeatMapScreen = heatMap,
                    ListPoints = points
                });
                string uri = allScreen[0].UriPage;
                allScreen.RemoveAll(s => s.UriPage.Equals(uri));
            }

            return result;
        }
        #endregion

        #region choose Record
        public async Task GetRecordScreens(RecordPrototype record)
        {
            RingContentVisibility = true;
            using (var db = new PrototypingContext())
            {
                RecordModel = db.RecordsPrototype.Single(r => r.RecordPrototypeId == record.RecordPrototypeId);
                await db.Entry(RecordModel).Collection(r => r.Screens).LoadAsync();
                if (!string.IsNullOrEmpty(RecordModel.PathToVideo))
                {
                    StorageFile videoFile = await StorageFile.GetFileFromPathAsync(RecordModel.PathToVideo);
                    Windows.UI.Xaml.Controls.MediaPlayerElement player = new Windows.UI.Xaml.Controls.MediaPlayerElement();
                    player.AreTransportControlsEnabled = true;
                    player.Source = MediaSource.CreateFromStorageFile(videoFile);
                    RecordVideo = player;
                    VideoIconVisibility = true;
                }
                else
                {
                    VideoIconVisibility = false;
                }
                Screens = await FileToImageTransform(RecordModel.Screens);
            }
            RingContentVisibility = false;
        }

        private async Task<ObservableCollection<RecordScreenPrototypeModel>> FileToImageTransform(List<RecordsScreen> dbScreens)
        {
            ObservableCollection<RecordScreenPrototypeModel> result = new ObservableCollection<RecordScreenPrototypeModel>();
            foreach (RecordsScreen dbScreen in dbScreens)
            {
                WriteableBitmap heatScreen = await HeatMapFunctions.AsWrBitmapFromFile(dbScreen.PathToHeatMapScreen);
                WriteableBitmap originalScreen = await HeatMapFunctions.AsWrBitmapFromFile(dbScreen.PathToOriginalScreen);

                result.Add(new RecordScreenPrototypeModel()
                {
                    OriginalScreen = originalScreen,
                    HeatMapScreen = heatScreen,
                    ListPoints = dbScreen.Points,
                    UriPage = dbScreen.UriPage
                });
            }
            return result;
        }
        #endregion
    }
}
