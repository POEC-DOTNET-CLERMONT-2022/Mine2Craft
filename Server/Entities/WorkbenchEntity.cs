using System;

namespace Entities;

public class WorkbenchEntity : IBaseEntity
{
    public Guid Id { get; set; }
    
    public int Position { get; set; }
    
    public Guid CompleteItemId { get; set; }
    public CompleteItemEntity CompleteItem { get; set; }
    
    public Guid ItemId { get; set; }
    public ItemEntity Item { get; set; }
}