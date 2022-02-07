

namespace Dtos
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte isCombustible { get; set; }
        public byte isCooked { get; set; }

    }
}
