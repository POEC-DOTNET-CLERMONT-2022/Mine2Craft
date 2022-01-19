using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Persistance
{
    public interface IRepositoryGeneric<T>
    {
        IEnumerable<T> GetAllCompleteItems();

        T GetSingleCompleteItem(Guid id);

        void CreateCompleteItem(T t);

        void DeleteCompleteItem(Guid id);
    }
}
