using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFixture;
using AutoMapper;
using Dtos;
using Entities;
using Persistance.Manager.CompleteItem;

namespace Persistance
{
    public class FakeCompleteItemManager : ICompleteItemManager
    {

        private readonly Fixture _fixture = new Fixture();
        public IMapper Mapper { get; set; }

        public IEnumerable<CompleteItemDto> GetAllCompleteItems()
        {
            return Mapper.Map<IEnumerable<CompleteItemDto>>(_fixture.CreateMany<CompleteItemEntity>(10));
        }

        public CompleteItemDto GetSingleCompleteItem(Guid id)
        {
            IEnumerable<CompleteItemDto> completeItemDtos = GetAllCompleteItems();

            List<CompleteItemDto> completeItemDtosList = completeItemDtos.ToList();

            completeItemDtosList.Add(new CompleteItemDto{Description = "test", Durability = 50, Id = id, Name = "test"});

            completeItemDtos = completeItemDtosList;

            return completeItemDtos.SingleOrDefault(completeItemDto => completeItemDto.Id == id);
        }

        public int CreateCompleteItem(CompleteItemDto completeItemDto)
        {
            IEnumerable<CompleteItemDto> completeItemDtos = GetAllCompleteItems();

            List<CompleteItemDto> completeItemDtosList = completeItemDtos.ToList();

            completeItemDtosList.Add(completeItemDto);

            completeItemDtos = completeItemDtosList;

            return completeItemDtos.Count();
        }

        public int DeleteCompleteItem(Guid id)
        {
            CompleteItemDto completeItemDto = new CompleteItemDto { Description = "test", Durability = 50, Id = id, Name = "test" };

            IEnumerable<CompleteItemDto> completeItemDtos = GetAllCompleteItems();

            List<CompleteItemDto> completeItemDtosList = completeItemDtos.ToList();

            completeItemDtosList.Add(completeItemDto);

            completeItemDtosList.Remove(completeItemDto);

            completeItemDtos = completeItemDtosList;

            return completeItemDtos.Count();
        }
    }
}
