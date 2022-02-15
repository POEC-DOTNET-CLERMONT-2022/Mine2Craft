using System;
using System.Globalization;
using System.Windows.Data;

namespace Mine2CraftWinApp.Converter;

public class CheckRadioButtonConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string)
        {
            if (value.Equals("True") || value.Equals("tools") && parameter.Equals("tools")) return true;

            if (value.Equals("True") || value.Equals("armors") && parameter.Equals("armors")) return true;
        }

        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}