using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class SqlRepositoryGeneric<T> : IRepositoryGeneric<T> where T : class, IBaseEntity, new()
    {
        private DbContext SqlContext { get; }

        public SqlRepositoryGeneric(DbContext sqlContext)
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
            
            //TODO:: create a new class with an Id and then use it to delete

            SqlContext.Remove(completeItemEntityToDelete);

            return SqlContext.SaveChanges();
        }
    }
}
