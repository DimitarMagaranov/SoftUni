using P03_SalesDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity => entity.Property(c => c.Email).IsUnicode(false));

            modelBuilder.Entity<Customer>(entity => entity.Property(c => c.CreditCardNumber).IsUnicode(false));

            modelBuilder.Entity<Product>(entity => entity.Property(p => p.Description).HasDefaultValue("No description"));

            modelBuilder.Entity<Sale>(entity => entity.Property(s => s.Date).HasDefaultValueSql("GETDATE()"));
        }
    }
}
