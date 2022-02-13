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
        
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
            //dotnet ef migrations add  InitialCreate --project Persistance --startup-project Mine2CraftApi
            
            //dotnet ef database update --project Persistance --startup-project Mine2CraftApi
            
            //dotnet ef migrations remove --project Persistance --startup-project Mine2CraftApi
        }

        public SqlDbContext()
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-KN0N952\ALEXPRESS;User id=sa;Password = mdpbdd;Initial Catalog=Mine2Craft;Integrated Security=True;");
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Mine2Craft;Integrated Security=True");
        }
        
        public DbSet<CompleteItemEntity> CompleteItems { get; set; }
        public DbSet<ToolEntity> Tools { get; set; }
        public DbSet<ArmorEntity> Armors { get; set; }

        public DbSet<UserEntity> Users { get; set; }
        
        public DbSet<WorkbenchEntity> Workbenches { get; set; }
        
        public DbSet<ItemEntity> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompleteItemEntity>()
                .HasMany(ci => ci.Workbenches)
                .WithOne(w => w.CompleteItem)
                .HasForeignKey(w => w.CompleteItemId);
            
            modelBuilder.Entity<CompleteItemEntity>().Navigation(ci => ci.Workbenches).AutoInclude();

            modelBuilder.Entity<CompleteItemEntity>()
                .HasDiscriminator(ci => ci.CompleteItemType)
                .HasValue<ToolEntity>("tools")
                .HasValue<ArmorEntity>("armors");

            modelBuilder.Entity<WorkbenchEntity>()
                .HasOne(w => w.Item)
                .WithMany(i => i.Workbenches)
                .HasForeignKey(w => w.ItemId);

            modelBuilder.Entity<WorkbenchEntity>().Navigation(w => w.Item).AutoInclude();

            modelBuilder.Entity<ToolEntity>()
                .Property(t => t.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<WorkbenchEntity>()
                .Property(w => w.Id).ValueGeneratedOnAdd();
        }
        
    }
}
