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
        public string Description { get; set; }

    }
}