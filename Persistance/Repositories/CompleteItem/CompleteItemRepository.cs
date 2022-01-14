using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    internal class CompleteItemRepository : ICompleteItemRepository
    {
        private DbContext SqlContext { get; }

        public CompleteItemRepository(DbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public IEnumerable<CompleteItemEntity> GetAllCompleteItems()
        {
            return SqlContext.Set<CompleteItemEntity>();
        }

        public CompleteItemEntity GetSingleCompleteItem(short id)
        {
            throw new NotImplementedException();
        }

        public void CreateCompleteItem(CompleteItemEntity completeItemEntityToCreate)
        {
            SqlContext.Add(completeItemEntityToCreate);

            SqlContext.SaveChanges();
        }
    }
}
