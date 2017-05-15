using CourseWork_2.HeatMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace CourseWork_2.DataBase.DBModels
{
    public class RecordScreen
    {
        public int RecordScreenId { get; set; }
        public string UriPage { get; set; }
        public string PathToOriginalScreen { get; set; }
        public string PathToHeatMapScreen { get; set; }
        public string PointsText { get; set; }
        public List<HeatPoint> Points
        {
            get
            {
                List<HeatPoint> list = new List<HeatPoint>();
                string[] pointsArr = PointsText.Split(';');
                foreach (string point in pointsArr)
                {
                    if (!point.Equals(""))
                    {
                        string[] p = point.Split(',');
                        list.Add(new HeatPoint(int.Parse(p[0]), int.Parse(p[1])));
                    }
                }
                return list;
            }
            set
            {
                if (value.Count != 0)
                    foreach (HeatPoint point in value)
                    {
                        PointsText += point.X + "," + point.Y + ";";
                    }
                else
                    PointsText = "";
            }
        }

        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}
