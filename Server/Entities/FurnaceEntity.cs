using System;

namespace Entities;

public class FurnaceEntity : IBaseEntity
{
    public Guid Id { get; set; }
    
    public Guid ItemBeforeCookingId { get; set; }
    public ItemEntity? ItemBeforeCooking { get; set; }
    
    public Guid ItemAfterCookingId { get; set; }
    public ItemEntity? ItemAfterCooking { get; set; }
}