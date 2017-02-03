using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace CourseWork_2.Converters
{
    public class RingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility;

            if (parameter != null && parameter.ToString().Equals("content"))
                visibility = (bool)value ? Visibility.Collapsed : Visibility.Visible;
            else
                visibility = (bool)value ? Visibility.Visible : Visibility.Collapsed;

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = (Visibility)value;
            bool result = true;
            if (visibility.Equals(Visibility.Collapsed))
                result = false;

            return result;
        }
    }
}
