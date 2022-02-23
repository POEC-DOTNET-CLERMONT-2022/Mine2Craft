namespace Dtos;

public class FurnaceDto
{
    public Guid Id { get; set; }
    
    public Guid ItemBeforeCookingId { get; set; }
    public ItemDto? ItemBeforeCooking { get; set; }
    
    public Guid ItemAfterCookingId { get; set; }
    public ItemDto? ItemAfterCooking { get; set; }
    
}