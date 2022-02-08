using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using Entities;
using Models;

namespace Mine2CraftWinApp.Profile
{
    internal class CompleteItemProfile : AutoMapper.Profile
    {
        public CompleteItemProfile()
        {
            CreateMap<CompleteItemDto, CompleteItemModel>()
                .IncludeAllDerived();
            
            CreateMap<ArmorDto, ArmorModel>().ReverseMap();
            CreateMap<ToolDto, ToolModel>().ReverseMap();
        }
    }
}
