using CourseWork_2.DataBase;
using System;
using System.Linq;
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
                    int records = db.Records.Count(r => r.UserId == Id);
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
