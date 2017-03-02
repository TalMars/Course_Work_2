using CourseWork_2.HeatMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace CourseWork_2.Model
{
    public class RecordScreenPrototypeModel
    {
        private const double scaleNumber = 0.3333;

        public RecordScreenPrototypeModel(string uriPage, WriteableBitmap screenshot)
        {
            UriPage = uriPage;
            OriginalScreen = screenshot;
            ListPoints = new List<HeatPoint>();
        }

        public RecordScreenPrototypeModel()
        {
        }

        public string UriPage { get; set; }

        public WriteableBitmap OriginalScreen { get; set; }

        public WriteableBitmap HeatMapScreen { get; set; }

        public List<HeatPoint> ListPoints { get; set; }

        public double WidthImage { get { return OriginalScreen.PixelWidth * scaleNumber; } }

        public double HeightImage { get { return OriginalScreen.PixelHeight * scaleNumber; } }

    }
}
