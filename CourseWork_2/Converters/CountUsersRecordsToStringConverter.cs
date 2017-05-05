using CourseWork_2.DataBase;
using CourseWork_2.DataBase.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CourseWork_2.Converters
{
    public class CountUsersRecordsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int Id = (int)value;
            string resultText = "";

            using (var db = new PrototypingContext())
            {
                if (parameter.ToString().Equals("prototype"))
                {
                    //Prototype prototype = db.Prototypes.Single(p => p.PrototypeId == Id);
                    //List<UserPrototype> users = prototype.Users;
                    int users = db.Users.Count(u => u.PrototypeId == Id);
                    if (users > 0)
                    {
                        resultText = users + " users";

                        int records = db.Users.Where(u => u.PrototypeId == Id).Sum(u => u.Records.Count());
                        if (records > 0)
                            resultText += ", " + records + "records";
                        else
                            resultText = "No records yet";
                    }
                    else
                    {
                        resultText = "No records yet";
                    }
                }

                if (parameter.ToString().Equals("user"))
                {
                    //int records = db.Users.Single(u => u.UserPrototypeId == Id).Records.Count();
                    int records = db.RecordsPrototype.Count(r => r.UserId == Id);
                    if (records > 0)
                        resultText += records + " records";
                    else
                        resultText = "No records yet";
                }
            }

            return resultText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
