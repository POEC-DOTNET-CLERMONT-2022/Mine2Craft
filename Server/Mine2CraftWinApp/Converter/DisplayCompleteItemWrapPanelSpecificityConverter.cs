using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Mine2CraftWinApp.Converter;

[ValueConversion(typeof(string), typeof(Visibility))]
public class DisplayCompleteItemWrapPanelSpecificityConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string)
        {
            if(value.Equals("tools") && parameter.Equals("tools")) return Visibility.Visible;

            if (value.Equals("armors") && parameter.Equals("armors")) return Visibility.Visible;
        }
        
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}