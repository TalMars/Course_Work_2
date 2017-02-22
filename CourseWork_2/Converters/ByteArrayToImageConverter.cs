using CourseWork_2.HeatMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace CourseWork_2.Converters
{
    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return HeatMapFunctions.AsBitmapImage((byte[])value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return HeatMapFunctions.AsByteArray((WriteableBitmap)value);
        }
    }
}
