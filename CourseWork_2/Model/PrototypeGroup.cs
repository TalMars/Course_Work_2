using CourseWork_2.DataBase.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.Model
{
    public class PrototypeGroup
    {
        public string Name { get; set; }
        public bool IsEnable { get; set; }
        public List<Prototype> Items { get; set; }
    }
}
