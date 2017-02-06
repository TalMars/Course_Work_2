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
        private WriteableBitmap screenPage;
        private WriteableBitmap heatMapScreen;
        private string pageUri;
        private List<HeatPoint> listPoints;
        private double _widthImage;
        private double _heightImage;
        private const double scaleNumber = 0.3333;

        public ReviewPrototypeModel(string uriPage, WriteableBitmap screenshot)
        {
            pageUri = uriPage;
            screenPage = screenshot;
            listPoints = new List<HeatPoint>();

            _widthImage = screenshot.PixelWidth * scaleNumber;
            _heightImage = screenshot.PixelHeight * scaleNumber;
        }

        public string UriPage
        {
            get
            {
                return pageUri;
            }
        }

        public WriteableBitmap ScreenPage
        {
            get { return screenPage; }
        }

        public WriteableBitmap HeatMapScreen
        {
            get { return heatMapScreen; }
            set { heatMapScreen = value; }
        }

        public List<HeatPoint> ListPoints
        {
            get { return listPoints; }
            set { listPoints = value; }
        }

        public double WidthImage
        {
            get { return _widthImage; }
            set { _widthImage = value; }
        }

        public double HeightImage
        {
            get { return _heightImage; }
            set { _heightImage = value; }
        }

    }
}
