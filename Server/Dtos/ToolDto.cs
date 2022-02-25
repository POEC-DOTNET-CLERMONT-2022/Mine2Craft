using System.Text.Json.Serialization;

namespace Dtos;

public class ToolDto : CompleteItemDto
{
    public int AttackPoint { get; set; }

    public ToolDto(Guid id, string name, int durability, string description, ICollection<WorkbenchDto> workbenches, int attackPoint) : base(id, name, durability, description, workbenches)
    {
        AttackPoint = attackPoint;
    }
}