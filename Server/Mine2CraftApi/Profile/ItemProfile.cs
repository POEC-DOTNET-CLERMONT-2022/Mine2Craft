using Dtos;
using Entities;

namespace Mine2Craft.Profile
{
    public class ItemProfile : AutoMapper.Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemEntity, ItemDto>().ReverseMap();
        }
    }
}
