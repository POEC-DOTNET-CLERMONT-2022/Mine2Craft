using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dtos;
using Entities;
using Models;


namespace Mine2CraftWebApp.Factories
{
    public static class CompleteItemFactory
    {
        public static IEnumerable<CompleteItemDto> ToDto(this IEnumerable<CompleteItem> completeItems)
        {
            foreach (var completeItem in completeItems)
            {
                yield return completeItem.ToDto();
            }
        }
        
        public static IEnumerable<CompleteItemDto> ToDto(this IEnumerable<CompleteItemEntity> completeItems)
        {
            foreach (var completeItem in completeItems)
            {
                yield return completeItem.ToDto();
            }
        }
        
        
        public static CompleteItemDto ToDto(this CompleteItem completeItem)
        {
            return new CompleteItemDto() { Id = completeItem.Id, Name = completeItem.Name, Description = completeItem.Description, Durability = completeItem.Durability};
        }
        
        public static CompleteItemDto ToDto(this CompleteItemEntity completeItem)
        {
            return new CompleteItemDto() { Id = completeItem.Id, Name = completeItem.Name, Description = completeItem.Description, Durability = completeItem.Durability };
        }
        
        
        public static IEnumerable<CompleteItem> ToModel(this IEnumerable<CompleteItemDto> completeItemDtos)
        {
            foreach (var completeItemDto in completeItemDtos)
            {
                yield return completeItemDto.ToModel();
            }
        }
        
        
        public static CompleteItem ToModel(this CompleteItemDto completeItemDto)
        {
            return new Models.CompleteItem() { Id = completeItemDto.Id, Name = completeItemDto.Name, Description = completeItemDto.Description, Durability = completeItemDto.Durability };
        }
    }
}