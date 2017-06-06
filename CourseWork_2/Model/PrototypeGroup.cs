using CourseWork_2.DataBase.DBModels;
using System.Collections.Generic;

namespace CourseWork_2.Model
{
    public class PrototypeGroup
    {
        public string Name { get; set; }
        public bool IsEnable { get; set; }
        public List<Prototype> Items { get; set; }
    }
}
