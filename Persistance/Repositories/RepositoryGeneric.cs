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

        public IEnumerable<T> GetAllCompleteItems()
        {
            return SqlContext.Set<T>();
        }

        public T GetSingleCompleteItem(Guid id)
        {
            return GetAllCompleteItems().Single(entity => entity.Id == id);
        }

        public void CreateCompleteItem(T entityToCreate)
        {
            SqlContext.Add(entityToCreate);

            SqlContext.SaveChanges();
        }

        public void DeleteCompleteItem(Guid id)
        {
            var completeItemEntityToDelete = GetSingleCompleteItem(id);

            SqlContext.Remove(completeItemEntityToDelete);

            SqlContext.SaveChanges();
        }
    }
}
