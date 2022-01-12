﻿using System;
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
            throw new NotImplementedException();
        }

        public CompleteItemEntity GetSingleCompleteItem(short id)
        {
            throw new NotImplementedException();
        }
    }
}
