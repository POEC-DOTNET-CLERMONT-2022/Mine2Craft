using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using Entities;
using Models;

namespace MapperCustom.Profile
{
    public class CompleteItemProfile : AutoMapper.Profile
    {
        public CompleteItemProfile()
        {
            CreateMap<CompleteItemDto, CompleteItemEntity>().ReverseMap();
            CreateMap<CompleteItemDto, CompleteItemModel>().ReverseMap();
        }
    }
}
