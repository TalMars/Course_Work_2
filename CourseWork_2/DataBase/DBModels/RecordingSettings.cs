using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataBase.DBModels
{
    public class RecordingSettings
    {
        public int RecordingSettingsId { get; set; }
        //public float DownScale { get; set; }
        //public int MaxFPS { get; set; }
        public bool FrontCamera { get; set; }
        public bool Touches { get; set; }
        //public bool SavingTouches { get; set; }

        public int RecordPrototypeId { get; set; }
        public RecordPrototype RecordPrototype { get; set; }
    }
}
