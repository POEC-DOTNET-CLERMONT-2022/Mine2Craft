using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Persistance
{
    public interface IRepositoryGeneric<T>
    {
        IEnumerable<T> GetAll();

        T GetSingle(Guid id);

        int Create(T t);

        int Delete(Guid id);
    }
}
