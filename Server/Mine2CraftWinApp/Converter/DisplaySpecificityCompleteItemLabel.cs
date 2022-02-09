using System;
using System.Globalization;
using System.Windows.Data;
using Models;

namespace Mine2CraftWinApp.Converter;

public class DisplaySpecificityCompleteItemLabel : IValueConverter
{
    public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null)
        {
            if (typeof(ToolModel) == value.GetType()) return "Attaque :";

            if (typeof(ArmorModel) == value.GetType()) return "Armure :";
        }
        
        return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}