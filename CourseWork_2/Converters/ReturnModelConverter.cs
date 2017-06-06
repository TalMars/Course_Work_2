using System;
using Windows.UI.Xaml.Data;

namespace CourseWork_2.Converters
{
    public class ReturnModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
