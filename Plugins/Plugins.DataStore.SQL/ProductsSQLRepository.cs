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
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategoryID(int categoryID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int productID, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
