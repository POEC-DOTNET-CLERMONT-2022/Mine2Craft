using System.Text.Json.Serialization;

namespace Dtos
{
    public class CompleteItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Durability { get; set; }
        public string? Description { get; set; }
        
        public string? CompleteItemType { get; set; }
        public IEnumerable<WorkbenchDto> Workbenches { get; set; }
        
        public CompleteItemDto(Guid id, string name, int durability, string description,
            ICollection<WorkbenchDto> workbenches)
        {
            Id = id;
            Name = name;
            Durability = durability;
            Description = description;
            Workbenches = workbenches;
        }
        
    }
}