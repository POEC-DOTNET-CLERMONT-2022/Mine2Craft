using System.Text.Json.Serialization;

namespace Dtos;

public class ArmorDto : CompleteItemDto
{
    [JsonPropertyName("armorPoint")]
    public int ArmorPoint { get; set; }
    
    public ArmorDto(Guid id, string name, int durability, string description, ICollection<WorkbenchDto> workbenches) : base(id, name, durability, description, workbenches)
    {
    }
}