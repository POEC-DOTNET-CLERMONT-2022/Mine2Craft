using Dtos;
using Models;

namespace Mine2CraftWinApp.Profile
{
    internal class CompleteItemProfile : AutoMapper.Profile
    {
        public CompleteItemProfile()
        {
            CreateMap<CompleteItemDto, CompleteItemModel>()
                .IncludeAllDerived();
            
            CreateMap<CompleteItemModel, CompleteItemDto>()
                .IncludeAllDerived();
            
            CreateMap<ArmorDto, ArmorModel>().ReverseMap();
            CreateMap<ToolDto, ToolModel>().ReverseMap();
            
            
            CreateMap<WorkbenchDto, WorkbenchModel>().ReverseMap();
            CreateMap<ItemDto, ItemModel>().ReverseMap();
        }
    }
}
