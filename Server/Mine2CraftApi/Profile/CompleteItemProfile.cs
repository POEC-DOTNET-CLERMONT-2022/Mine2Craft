using Dtos;
using Entities;

namespace Mine2CraftApi.Profile
{
    public class CompleteItemProfile : AutoMapper.Profile
    {
        public CompleteItemProfile()
        {
            CreateMap<CompleteItemEntity, CompleteItemDto>()
                .IncludeAllDerived();
            
            CreateMap<CompleteItemDto, CompleteItemEntity>()
                .IncludeAllDerived();
            
            CreateMap<ArmorEntity, ArmorDto>().ReverseMap();
            CreateMap<ToolEntity, ToolDto>().ReverseMap();
            
            CreateMap<WorkbenchEntity, WorkbenchDto>().ReverseMap();
            CreateMap<ItemEntity, ItemDto>().ReverseMap();
            
            
        }
    }
}
