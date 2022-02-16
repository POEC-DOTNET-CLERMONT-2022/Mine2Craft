using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Dtos;

namespace Models;

public class ArmorModel : CompleteItemModel
{
    protected int _armorPoint;
    
    public ArmorModel()
    {
        
    }

    [JsonConstructorAttribute]
    public ArmorModel(Guid id, string name, int durability, string description, ICollection<WorkbenchModel> workbenches, string completeItemType, int armorPoint) : base(id, name, durability, description, workbenches, completeItemType)
    {
        ArmorPoint = armorPoint;
    }
    
    public ArmorModel(string name, int durability, string description, ICollection<WorkbenchModel> workbenches, string completeItemType, int armorPoint) : base(Guid.Empty, name, durability, description, workbenches, completeItemType)
    {
        ArmorPoint = armorPoint;
    }

    
    public int ArmorPoint
    {
        get { return _armorPoint; }
        set
        {
            if (_armorPoint != value)
            {
                _armorPoint = value;
                OnNotifyPropertyChanged();
            }
        }
    }
}