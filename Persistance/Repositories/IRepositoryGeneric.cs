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

        int CreateCompleteItem(T t);

        int DeleteCompleteItem(Guid id);
    }
}
