using Microsoft.EntityFrameworkCore;
using WMS.DataLayer.Models;

namespace WMS.DataLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
