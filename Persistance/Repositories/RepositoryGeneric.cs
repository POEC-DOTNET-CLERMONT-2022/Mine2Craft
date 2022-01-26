using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    internal class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class, IBaseEntity, new()
    {
        private DbContext SqlContext { get; }

        public RepositoryGeneric(DbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public IEnumerable<T> GetAll()
        {
            return SqlContext.Set<T>();
        }

        public T GetSingle(Guid id)
        {
            return GetAll().Single(entity => entity.Id == id);
        }

        public int Create(T entityToCreate)
        {
            SqlContext.Add(entityToCreate);

            return SqlContext.SaveChanges();
        }

        public int Delete(Guid id)
        {
            var completeItemEntityToDelete = GetSingle(id);

            SqlContext.Remove(completeItemEntityToDelete);

            return SqlContext.SaveChanges();
        }
    }
}
