using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace CourseWork_2.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = Visibility.Visible;

            if (parameter != null && parameter.ToString().Equals("right"))
                visibility = (bool)value ? Visibility.Collapsed : Visibility.Visible;
            if (parameter != null && parameter.ToString().Equals("inverse"))
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
