using System;

namespace Models;

public class FurnaceModel
{
    public Guid Id { get; set; }
    
    public Guid ItemBeforeCookingId { get; set; }
    public ItemModel? ItemBeforeCooking { get; set; }
    
    public Guid ItemAfterCookingId { get; set; }
    public ItemModel? ItemAfterCooking { get; set; }
}