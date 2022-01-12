using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Persistance
{
    public interface ICompleteItemRepository
    {
        IEnumerable<CompleteItemEntity> GetAllCompleteItems();

        CompleteItemEntity GetSingleCompleteItem(short id);
    }
}
