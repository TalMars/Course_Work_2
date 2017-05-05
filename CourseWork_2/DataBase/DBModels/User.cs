using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataBase.DBModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastRecordingDate { get; set; }

        public List<Record> Records { get; set; }

        public int PrototypeId { get; set; }
        public Prototype Prototype { get; set; }
    }
}
