using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Dtos;
using Entities;
using Models;
using Persistance.Manager.CompleteItem;

namespace Persistance
{
    public class BddCompleteItemManager : ICompleteItemManager
    {
        
        private readonly RepositoryGeneric<CompleteItemEntity> _completeItemRepository;
        
        public IMapper Mapper { get; set; }

        public BddCompleteItemManager()
        {
            _completeItemRepository = new RepositoryGeneric<CompleteItemEntity>(new SqlDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Mine2Craft;Integrated Security=True"));
        }

        public IEnumerable<CompleteItemDto> GetAllCompleteItems()
        {
            return Mapper.Map<IEnumerable<CompleteItemDto>>(_completeItemRepository.GetAllCompleteItems());
        }

        public CompleteItemDto GetSingleCompleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public int CreateCompleteItem(CompleteItemDto completeItemDto)
        {
            var completeItemEntityToCreate = Mapper.Map<CompleteItemEntity>(completeItemDto);
            return _completeItemRepository.CreateCompleteItem(completeItemEntityToCreate);
        }

        public int DeleteCompleteItem(Guid id)
        {
            return _completeItemRepository.DeleteCompleteItem(id);
        }

    }
}
