using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class ToolEntity : CompleteItemEntity
{
    [Column("attackPoint")] 
    public int AttackPoint { get; set; }
}