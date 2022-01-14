using System;
using System.Collections.Generic;
using System.Linq;
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

        public CompleteItemEntity GetSingleCompleteItem(Guid id)
        {
            return GetAllCompleteItems().Single(completeItem => completeItem.Id == id);
        }

        public void CreateCompleteItem(CompleteItemEntity completeItemEntityToCreate)
        {
            SqlContext.Add(completeItemEntityToCreate);

            SqlContext.SaveChanges();
        }

        public void DeleteCompleteItem(Guid id)
        {
            CompleteItemEntity completeItemEntityToDelete = GetSingleCompleteItem(id);

            SqlContext.Remove(completeItemEntityToDelete);

            SqlContext.SaveChanges();
        }
    }
}
