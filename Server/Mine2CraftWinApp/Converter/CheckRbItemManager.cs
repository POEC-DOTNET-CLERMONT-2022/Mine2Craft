using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mine2CraftWinApp.Converter
{
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class CheckRbItemManager : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                //TODO : bizarre 
                if (value.Equals("True")) return Visibility.Visible;
                else return Visibility.Collapsed;

                //if (value.Equals("True") || value.Equals("armors") && parameter.Equals("armors")) return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
