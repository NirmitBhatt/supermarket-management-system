using CoreBusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID);

            //seeding data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Beverage", Description = "Beverage" },
                new Category { CategoryID = 2, Name = "Bakery", Description = "Bakery" },
                new Category { CategoryID = 3, Name = "Meat", Description = "Meat" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, CategoryID = 1, ProductName = "Iced Tea", Quantity = 100, Price = 1.99 },
                new Product { ProductID = 2, CategoryID = 1, ProductName = "Canada Dry", Quantity = 200, Price = 1.99 },
                new Product { ProductID = 3, CategoryID = 2, ProductName = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
                new Product { ProductID = 4, CategoryID = 2, ProductName = "White Bread", Quantity = 300, Price = 1.50 }
            );
        }
    }
}
