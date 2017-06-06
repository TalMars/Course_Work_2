using System;
using System.Collections.Generic;

namespace CourseWork_2.DataBase.DBModels
{
    public class Prototype
    {
        public int PrototypeId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastRecordingDate { get; set; }
        
        public List<User> Users { get; set; }
    }
}
