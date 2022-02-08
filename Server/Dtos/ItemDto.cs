using System.Text.Json.Serialization;

namespace Dtos;

public class ItemDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    public ItemDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}