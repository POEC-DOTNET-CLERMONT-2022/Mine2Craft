using System;
using System.Globalization;
using System.Windows.Data;
using Dtos;
using Models;

namespace Mine2CraftWinApp.Converter;

public class ItemInCraftTableConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null)
        {
            CompleteItemModel completeItem = (CompleteItemModel) value;
            
            foreach (var workbench in completeItem.Workbenches)
            {
                if (workbench.Position == (int) parameter)
                {
                    return workbench.Item.Name;
                }
            }
        }
        
        return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}