using System.Text.Json.Serialization;

namespace Dtos;

public class WorkbenchDto
{
    public Guid Id { get; set; }
    
    [JsonPropertyName("position")]
    public int Position { get; set; }
    
    public Guid ItemId { get; set; }
    
    [JsonPropertyName("item")]
    public ItemDto? Item { get; set; }

    
}