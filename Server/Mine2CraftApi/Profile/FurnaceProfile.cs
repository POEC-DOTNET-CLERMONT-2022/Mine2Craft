using Dtos;
using Entities;

namespace Mine2CraftApi.Profile;

public class FurnaceProfile : AutoMapper.Profile
{
    public FurnaceProfile()
    {
        CreateMap<FurnaceEntity, FurnaceDto>().ReverseMap();
    }
}