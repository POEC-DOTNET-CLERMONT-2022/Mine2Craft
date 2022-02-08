using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class ArmorEntity : CompleteItemEntity
{
    public Guid Id
    {
        get => base.Id;
        set => base.Id = value;
    }

    public string Name
    {
        get => base.Name;
        set => base.Name = value;
    }

    public int Durability
    {
        get => base.Durability;
        set => base.Durability = value;
    }

    public string Description
    {
        get => base.Description;
        set => base.Description = value;
    }

    [Column("armorPoint")] 
    public int ArmorPoint { get; set; }

    public ICollection<WorkbenchEntity> Workbenches
    {
        get => base.Workbenches;
        set => base.Workbenches = value;
    }
    
}