using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.Converters
{
    public class IconStartStopConverter : Windows.UI.Xaml.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Windows.UI.Xaml.Controls.Symbol symbol = (bool)value ? Windows.UI.Xaml.Controls.Symbol.Play : Windows.UI.Xaml.Controls.Symbol.Stop;
            return symbol;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Windows.UI.Xaml.Controls.Symbol symbol = (Windows.UI.Xaml.Controls.Symbol)value;
            bool result = true;
            if (symbol.Equals(Windows.UI.Xaml.Controls.Symbol.Stop))
                result = false;

            return result;
        }
    }
}
