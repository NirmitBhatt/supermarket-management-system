using CoreBusinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductsSQLRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductsSQLRepository(MarketContext db)
        {
            this.db = db;
        }
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productID)
        {
            var product = db.Products.Find(productID);
            if(product == null)
            {
                return;
            }
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product? GetProductByID(int productID, bool loadCategory = false)
        {
            if (loadCategory)
            {
                return db.Products
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.ProductID == productID);
            }
            else
            {
                return db.Products
                    .FirstOrDefault(x => x.ProductID == productID);
            }
        }

        public IEnumerable<Product> GetProducts(bool loadCategory)
        {
            if (loadCategory)
            {
                return db.Products.Include(x => x.Category)
                    .OrderBy(x => x.CategoryID)
                    .ToList();
            }
            else
            {
                return db.Products.OrderBy(x => x.CategoryID).ToList();
            }
        }

        public IEnumerable<Product> GetProductsByCategoryID(int categoryID)
        {
             return db.Products.Where(x => x.CategoryID == categoryID).ToList();
        }

        public void UpdateProduct(int productID, Product product)
        {
            if(productID != product.ProductID)
            {
                return;
            }
            var prod = db.Products.Find(productID);
            if (prod == null)
            {
                return;
            }
            prod.CategoryID = product.CategoryID;
            prod.ProductName = product.ProductName;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;

            db.SaveChanges();
        }
    }
}
