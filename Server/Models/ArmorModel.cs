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
    public ArmorModel(Guid id, string name, int durability, string description, ICollection<WorkbenchDto> workbenches, int armorPoint) : base(id, name, durability, description, workbenches)
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