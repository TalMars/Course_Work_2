using CourseWork_2.HeatMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace CourseWork_2.Model
{
    public class ReviewPrototypeModel
    {
        private const double scaleNumber = 0.3333;

        public ReviewPrototypeModel(string uriPage, WriteableBitmap screenshot)
        {
            UriPage = uriPage;
            ScreenPage = screenshot;
            ListPoints = new List<HeatPoint>();

            WidthImage = screenshot.PixelWidth * scaleNumber;
            HeightImage = screenshot.PixelHeight * scaleNumber;
        }

        public string UriPage { get; private set; }

        public WriteableBitmap ScreenPage { get; private set; }

        public WriteableBitmap HeatMapScreen { get; set; }

        public List<HeatPoint> ListPoints { get; set; }

        public double WidthImage { get; set; }

        public double HeightImage { get; set; }

    }
}
