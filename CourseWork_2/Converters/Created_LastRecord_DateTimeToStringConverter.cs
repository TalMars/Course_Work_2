using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CourseWork_2.Converters
{
    public class Created_LastRecord_DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime dateTime = (DateTime)value;
            CultureInfo lang = new CultureInfo("en-US");
            string resultText = "";
            
            string time = dateTime.ToString("d MMM yyyy HH:mm", lang);
            if (parameter.ToString().Equals("created"))
                resultText = "Created: " + time;
            if (parameter.ToString().Equals("added"))
                resultText = "Added: " + time;
            if (parameter.ToString().Equals("lastRecord"))
                resultText = "Last Record: " + time;

            return resultText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
