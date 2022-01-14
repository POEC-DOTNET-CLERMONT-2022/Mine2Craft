using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Persistance
{
    public class BddCompleteItemManager : ICompleteItemRepository
    {

        private readonly CompleteItemRepository _completeItemRepository;

        public BddCompleteItemManager()
        {
            _completeItemRepository = new CompleteItemRepository(new SqlDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Mine2Craft;Integrated Security=True"));
        }
        
        public IEnumerable<CompleteItemEntity> GetAllCompleteItems()
        {
            return _completeItemRepository.GetAllCompleteItems();
        }

        public CompleteItemEntity GetSingleCompleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CreateCompleteItem(CompleteItemEntity completeItemEntityToCreate)
        {
            _completeItemRepository.CreateCompleteItem(completeItemEntityToCreate);
        }

        public void DeleteCompleteItem(Guid id)
        {
            _completeItemRepository.DeleteCompleteItem(id);
        }
    }
}
