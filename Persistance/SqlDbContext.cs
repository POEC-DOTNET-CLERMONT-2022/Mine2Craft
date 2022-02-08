using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {
        }
        public SqlDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KN0N952\ALEXPRESS;User id=sa;Password = mdpbdd;Initial Catalog=Mine2Craft;Integrated Security=True;");
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Mine2Craft;Integrated Security=True");
        }

        public virtual DbSet<ItemEntity> Items { get; set; }
        public virtual DbSet<WorkbenchEntity> Workbenchs { get; set; }
        public virtual DbSet<CompleteItemEntity> CompleteItems { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<ItemEntity>()
                .Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<ItemEntity>()
                .HasMany<WorkbenchEntity>(i => i.Workbenches)
                .WithOne(w => w.CurrentItem)
                .HasForeignKey(w => w.CurrentItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompleteItemEntity>()
                .Property(w => w.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CompleteItemEntity>()
                .HasMany<WorkbenchEntity>(ci => ci.Workbenches)
                .WithOne(w => w.CurrentCompleteItem)
                .HasForeignKey(w => w.CurrentItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkbenchEntity>()
                .Property(w => w.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<WorkbenchEntity>()
                .HasOne<ItemEntity>(w => w.CurrentItem)
                .WithMany(i => i.Workbenches)
                .HasForeignKey(w => w.CurrentItemId);
            modelBuilder.Entity<WorkbenchEntity>()
                .HasOne<CompleteItemEntity>(w => w.CurrentCompleteItem)
                .WithMany(i => i.Workbenches)
                .HasForeignKey(w => w.CurrentCompleteItemId);

            modelBuilder.Entity<UserEntity>()
                .Property(e => e.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
