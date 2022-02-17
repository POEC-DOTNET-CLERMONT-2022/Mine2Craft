using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class ArmorEntity : CompleteItemEntity
{
    [Column("armorPoint")] 
    public int ArmorPoint { get; set; }
}