using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CourseWork_2.Converters
{
    public class DatesVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Windows.UI.Xaml.Visibility resultVisibility = Windows.UI.Xaml.Visibility.Visible;
            DateTime dateTime = (DateTime)value;
            if (dateTime == DateTime.MinValue && parameter.ToString().Equals("lastRecord"))
                resultVisibility = Windows.UI.Xaml.Visibility.Collapsed;
            return resultVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
