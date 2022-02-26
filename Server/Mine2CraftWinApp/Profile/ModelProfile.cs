using Dtos;
using Models;

namespace Mine2CraftWinApp.Profile
{
    public class ModelProfile : AutoMapper.Profile
    {
        public ModelProfile()
        {
            CreateMap<ItemModel, ItemDto>().ReverseMap();
            CreateMap<FurnaceModel, FurnaceDto>().ReverseMap();
        }
    }
}
