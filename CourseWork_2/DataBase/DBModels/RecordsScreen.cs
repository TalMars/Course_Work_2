using CourseWork_2.HeatMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace CourseWork_2.DataBase.DBModels
{
    public class RecordsScreen
    {
        public int RecordsScreenId { get; set; }
        public string UriPage { get; set; }
        public byte[] OriginalScreen { get; set; }
        public byte[] HeatMapScreen { get; set; }
        public double WidthImage { get; set; }
        public double HeightImage { get; set; }
        public string PointsText { get; set; }
        public List<HeatPoint> Points
        {
            get
            {
                List<HeatPoint> list = new List<HeatPoint>();
                string[] pointsArr = PointsText.Split(';');
                foreach (string point in pointsArr)
                {
                    string[] p = point.Split(',');
                    list.Add(new HeatPoint(int.Parse(p[0]), int.Parse(p[1])));
                }
                return list;
            }
            set
            {
                foreach (HeatPoint point in value)
                {
                    PointsText += point.X + "," + point.Y + ";";
                }
            }
        }

        public int RecordPrototypeId { get; set; }
        public RecordPrototype RecordPrototype { get; set; }
    }
}
