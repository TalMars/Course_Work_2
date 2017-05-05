using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataBase.DBModels
{
    public class Record
    {
        public int RecordId { get; set; }
        public string PathToVideo { get; set; }
        public DateTime CreatedDate { get; set; }

        public RecordSettings Settings { get; set; }
        public List<RecordScreen> Screens { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
