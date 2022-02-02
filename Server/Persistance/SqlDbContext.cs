using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance
{
    public class SqlDbContext : DbContext
    {
        public DbSet<CompleteItemEntity> CompleteItems { get; set; }
        
        public DbSet<UserEntity> Users { get; set; }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        protected SqlDbContext()
        {
            
        }
        
    }
}
