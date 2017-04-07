using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataBase.DBModels
{
    public class RecordPrototype
    {
        public int RecordPrototypeId { get; set; }
        public string PathToVideo { get; set; }
        public DateTime CreatedDate { get; set; }

        public RecordingSettings Settings { get; set; }
        public List<RecordsScreen> Screens { get; set; }

        public int UserPrototypeId { get; set; }
        public UserPrototype UserPrototype { get; set; }
    }
}
