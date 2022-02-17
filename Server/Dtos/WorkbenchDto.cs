using System.Text.Json.Serialization;

namespace Dtos;

public class WorkbenchDto
{
    public Guid Id { get; set; }
    
    public int Position { get; set; }
    
    public Guid ItemId { get; set; }
    
    public ItemDto? Item { get; set; }

    
}