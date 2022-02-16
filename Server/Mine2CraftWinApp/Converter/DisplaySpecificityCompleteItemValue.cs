using System;
using System.Globalization;
using System.Windows.Data;
using Dtos;
using Models;

namespace Mine2CraftWinApp.Converter;

public class DisplaySpecificityCompleteItemValue : IValueConverter
{
    public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null)
        {
            if (typeof(ToolModel) == value.GetType())
            {
                //TODO if(value is ToolModel model) 
                ToolModel tool = value as ToolModel;
                return tool.AttackPoint.ToString();
            }
            if (typeof(ArmorModel) == value.GetType())
            {
                //TODO if(value is ArmorModel model) 
                ArmorModel armor = value as ArmorModel;
                return armor.ArmorPoint.ToString();
            }
            
        }
        
        return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}