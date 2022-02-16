
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Dtos;

namespace Models;

public class ToolModel : CompleteItemModel
{
    private int _attackPoint;
    
    public ToolModel()
    {
        
    }
    
    [JsonConstructorAttribute]
    public ToolModel(Guid id, string name, int durability, string description, ICollection<WorkbenchModel> workbenches, string completeItemType, int attackPoint) : base(id, name, durability, description, workbenches, completeItemType)
    {
        AttackPoint = attackPoint;
    }
    
    public ToolModel(string name, int durability, string description, ICollection<WorkbenchModel> workbenches, string completeItemType, int attackPoint) : base(Guid.Empty, name, durability, description, workbenches, completeItemType)
    {
        AttackPoint = attackPoint;
    }
    
    public int AttackPoint
    {
        get { return _attackPoint; }
        set
        {
            if (_attackPoint != value)
            {
                _attackPoint = value;
                OnNotifyPropertyChanged();
            }
        }
    }
}