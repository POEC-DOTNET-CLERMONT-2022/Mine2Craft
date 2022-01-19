using AutoMapper;
using Dtos;
using Entities;
using Models;

namespace Mine2CraftApi.Profiles
{
    public class CompleteItemProfile : Profile
    {
        public CompleteItemProfile()
        {
            CreateMap<CompleteItemEntity, CompleteItemModel>().ReverseMap();
            CreateMap<CompleteItemModel, CompleteItemDto>().ReverseMap();
        }
    }
}
