using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Entities;
using Models;

namespace Persistance
{
    public class BddCompleteItemManager
    {
        
        private readonly RepositoryGeneric<CompleteItemEntity> _completeItemRepository;

        private IMapper _mapper;

        public BddCompleteItemManager(IMapper mapper)
        {
            _completeItemRepository = new RepositoryGeneric<CompleteItemEntity>(new SqlDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Mine2Craft;Integrated Security=True"));
            _mapper = mapper;
        }

        public IEnumerable<CompleteItemModel> GetAllCompleteItems()
        {
            return _mapper.Map<IEnumerable<CompleteItemModel>>(_completeItemRepository.GetAllCompleteItems());
        }

        public CompleteItemEntity GetSingleCompleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CreateCompleteItem(CompleteItemModel completeItemModel)
        {
            _completeItemRepository.CreateCompleteItem(_mapper.Map<CompleteItemEntity>(completeItemModel));
        }

        public void DeleteCompleteItem(Guid id)
        {
            _completeItemRepository.DeleteCompleteItem(id);
        }

    }
}
