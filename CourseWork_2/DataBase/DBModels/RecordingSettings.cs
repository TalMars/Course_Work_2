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
        public float DownScale { get; set; }
        public int MaxFPS { get; set; }
        public bool WithFrontCamera { get; set; }
        public bool WithTouches { get; set; }
        public bool WithTouchesLogging { get; set; }

        public int PrototypeId { get; set; }
        public Prototype Prototype { get; set; }
    }
}
