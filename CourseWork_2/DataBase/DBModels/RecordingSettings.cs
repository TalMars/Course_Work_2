using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataBase.DBModels
{
    public class RecordSettings
    {
        public int RecordSettingsId { get; set; }
        //public float DownScale { get; set; }
        //public int MaxFPS { get; set; }
        public bool FrontCamera { get; set; }
        public bool Touches { get; set; }
        //public bool SavingTouches { get; set; }

        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}
