using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Persistance
{
    public interface ICompleteItemRepository
    {
        IEnumerable<CompleteItemEntity> GetAllCompleteItems();

        CompleteItemEntity GetSingleCompleteItem(Guid id);

        void CreateCompleteItem(CompleteItemEntity completeItemEntityToCreate);

        void DeleteCompleteItem(Guid id);
    }
}
