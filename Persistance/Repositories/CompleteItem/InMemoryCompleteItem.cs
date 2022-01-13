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

        public CompleteItemEntity GetSingleCompleteItem(short id)
        {
            throw new NotImplementedException();
        }
    }
}
