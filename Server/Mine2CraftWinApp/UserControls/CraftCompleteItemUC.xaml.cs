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
        DependencyProperty.Register("WorkbenchCompleteItem", typeof(ICollection<WorkbenchModel>), typeof(CraftCompleteItemUC));
    
    private ICollection<WorkbenchModel> _workbenchCompleteItem;
    
    public ICollection<WorkbenchModel>? WorkbenchCompleteItem
    {
        get
        {
            //TODO : bcp trop complexe surtout pour un getter 
            var allPositions = new List<int> {1,2,3,4,5,6,7,8,9};

            var currentWorkbenches = GetValue(WorkbenchCompleteItemProperty) as List<WorkbenchModel>;

            var itemPositions = currentWorkbenches.Select(w => w.Position);

            var emptyPosition = allPositions.Except(itemPositions);

            var positionManaged = new List<WorkbenchModel>();

            foreach (var position in emptyPosition)
            {
                positionManaged.Add(new WorkbenchModel(position, null));
            }

            foreach (var workbench in currentWorkbenches)
            {
                positionManaged.Add(workbench);
            }

            var positionSorted = positionManaged.OrderBy(w => w.Position).ToList();

            return positionSorted;
        }
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