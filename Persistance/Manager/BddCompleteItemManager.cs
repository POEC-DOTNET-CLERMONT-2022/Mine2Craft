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

        //TODO implement class
        public IEnumerable<CompleteItemEntity> GetAllCompleteItems()
        {
            return _completeItemRepository.GetAllCompleteItems();
        }

        public CompleteItemEntity GetSingleCompleteItem(short id)
        {
            throw new NotImplementedException();
        }
    }
}
