using System.Text.Json.Serialization;

namespace Dtos
{
    public class CompleteItemDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("durability")]
        public int Durability { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
        
        [JsonPropertyName("completeItemType")]
        public string? CompleteItemType { get; set; }
        
        [JsonPropertyName("workbenches")]
        public ICollection<WorkbenchDto> Workbenches { get; set; }
        
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