using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ISBNDB_WPF_Example.Converter
{

    public class NotBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (targetType == typeof(bool))
            {
                return !((bool)value);
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (targetType == typeof(bool))
            {
                return !((bool)value);
            }
            else
                return false;
        }
    }

}
