using Dtos;
using Entities;

namespace Mine2CraftApi.Profile;

public class WorkbenchProfile : AutoMapper.Profile
{
    public WorkbenchProfile()
    {
        CreateMap<WorkbenchEntity, WorkbenchDto>().ReverseMap();
    }
}