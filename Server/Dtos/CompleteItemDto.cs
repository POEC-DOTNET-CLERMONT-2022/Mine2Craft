using System.Text.Json.Serialization;

namespace Dtos
{
    public class CompleteItemDto
    {

        //TODO : à supprimer 
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
        //TODO: dans les DTO on utilise plutôt des IEnumerable
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