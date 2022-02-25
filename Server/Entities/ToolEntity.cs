using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class ToolEntity : CompleteItemEntity
{
    public int AttackPoint { get; set; }
}