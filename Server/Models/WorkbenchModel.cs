using System;

namespace Models;

public class WorkbenchModel
{
    
    public Guid Id { get; set; } = Guid.Empty;
    public int Position { get; set; }
    
    public Guid ItemId { get; set; }
    public ItemModel Item { get; set; }
    

    public WorkbenchModel(int position, ItemModel item)
    {
        Position = position;
        Item = item;
    }

    public WorkbenchModel(int position, Guid itemId)
    {
        ItemId = itemId;
        Position = position;
    }
}