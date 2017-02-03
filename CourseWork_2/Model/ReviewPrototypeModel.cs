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
        private string pageUri;
        private List<HeatPoint> listPoints;

        public ReviewPrototypeModel(string uriPage, WriteableBitmap screenshot)
        {
            pageUri = uriPage;
            screenPage = screenshot;
            listPoints = new List<HeatPoint>();
        }

        public ReviewPrototypeModel(string uriPage, WriteableBitmap screenshot, List<HeatPoint> points)
        {
            pageUri = uriPage;
            screenPage = screenshot;
            listPoints = points;
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

        public List<HeatPoint> ListPoints
        {
            get { return listPoints; }
            set { listPoints = value; }
        }

    }
}
