using System.Text.Json.Serialization;

namespace Dtos
{
    public class CompleteItemDto
    {
        public CompleteItemDto(Guid id, string name, int durability, string? description)
        {
            Id = id;
            Name = name;
            Durability = durability;
            Description = description;
        }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("durability")]
        public int Durability { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

    }
}