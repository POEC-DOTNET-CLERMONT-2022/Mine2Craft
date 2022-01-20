using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Dtos;
using Entities;
using Models;
using Mapper;

namespace Persistance
{
    public class BddCompleteItemManager
    {
        
        private readonly RepositoryGeneric<CompleteItemEntity> _completeItemRepository;

        private Mapper.MapperCustom Mapper { get; } = new Mapper.MapperCustom();

        public BddCompleteItemManager()
        {
            _completeItemRepository = new RepositoryGeneric<CompleteItemEntity>(new SqlDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Mine2Craft;Integrated Security=True"));
        }

        public IEnumerable<CompleteItemEntity> GetAllCompleteItems()
        {
            return _completeItemRepository.GetAllCompleteItems();
        }

        public CompleteItemEntity GetSingleCompleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CreateCompleteItem(CompleteItemDto completeItemDto)
        {
            var completeItemEntityToCreate = Mapper.Mapper.Map<CompleteItemEntity>(completeItemDto);
            _completeItemRepository.CreateCompleteItem(completeItemEntityToCreate);
        }

        public void DeleteCompleteItem(Guid id)
        {
            _completeItemRepository.DeleteCompleteItem(id);
        }

    }
}
