using Dtos;
using Entities;

namespace Mine2CraftApi.Profile
{
    public class CompleteItemProfile : AutoMapper.Profile
    {
        public CompleteItemProfile()
        {
            CreateMap<CompleteItemDto, CompleteItemEntity>().ReverseMap();
        }
    }
}
