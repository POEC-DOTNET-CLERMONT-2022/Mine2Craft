using System.Text.Json.Serialization;

namespace Dtos
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public byte isCombustible { get; set; }
        public byte isCooked { get; set; }
        public Guid ItemBeforeCook { get; set; }
        public string ImagePath { get; set; }



        public ItemDto(Guid id, string name, string description, byte isCombustible, byte isCooked, Guid itemBeforeCook, string imagePath)
        {
            Id = id;
            Name = name;
            Description = description;
            this.isCombustible = isCombustible;
            this.isCooked = isCooked;
            ItemBeforeCook = itemBeforeCook;
            ImagePath = imagePath;
        }
    }
}
