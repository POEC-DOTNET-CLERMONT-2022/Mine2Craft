using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Persistance
{
    public class InMemoryCompleteItem : ICompleteItemRepository
    {
        //TODO class avec fixture pour faire des tests
        public IEnumerable<CompleteItemEntity> GetAllCompleteItems()
        {
            throw new NotImplementedException();
        }

        public CompleteItemEntity GetSingleCompleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public void CreateCompleteItem(CompleteItemEntity completeItemEntityToCreate)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompleteItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
