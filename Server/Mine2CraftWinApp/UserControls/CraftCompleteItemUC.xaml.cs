using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Dtos;
using Models;

namespace Mine2CraftWinApp.UserControls;

public partial class CraftCompleteItemUC : UserControl
{
    private static readonly DependencyProperty WorkbenchCompleteItemProperty = 
        DependencyProperty.Register("WorkbenchCompleteItem", typeof(ICollection<WorkbenchDto>), typeof(CraftCompleteItemUC));
    
    private ICollection<WorkbenchDto> _workbenchCompleteItem;
    
    public ICollection<WorkbenchDto>? WorkbenchCompleteItem
    {
        get { return GetValue(WorkbenchCompleteItemProperty) as ICollection<WorkbenchDto>; }
        set
        {
            if (_workbenchCompleteItem != value)
            {
                SetValue(WorkbenchCompleteItemProperty, value);
            }
        }
    }
    
    public CraftCompleteItemUC()
    {
        InitializeComponent();
    }

}