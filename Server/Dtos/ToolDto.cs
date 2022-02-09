using System.Text.Json.Serialization;

namespace Dtos;

public class ToolDto : CompleteItemDto
{
    [JsonPropertyName("attackPoint")]
    public int AttackPoint { get; set; }

    public ToolDto(Guid id, string name, int durability, string description, ICollection<WorkbenchDto> workbenches) : base(id, name, durability, description, workbenches)
    {
    }
}