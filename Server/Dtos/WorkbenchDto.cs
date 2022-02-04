using System.Text.Json.Serialization;

namespace Dtos;

public class WorkbenchDto
{
    [JsonPropertyName("position")]
    public int Position { get; set; }
    
    [JsonPropertyName("item")]
    public ItemDto Item { get; set; }
}