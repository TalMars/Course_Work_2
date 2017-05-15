using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataBase.DBModels
{
    public class EmotionFragment
    {
        public int EmotionFragmentId { get; set; }
        public long Start { get; set; }
        public long Duration { get; set; }
        public long? Interval { get; set; }

        public List<EmotionMeanScores> Scores { get; set; }

        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}
