using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductsInMemoryRepository : IProductRepository
    {
        private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;
        public ProductsInMemoryRepository(IViewSelectedCategoryUseCase viewSelectedCategoryUseCase)
        {
            this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
        }

        private List<Product> _products = new()
        {
            new Product { ProductID = 1, CategoryID = 1, ProductName = "Iced Tea", Quantity = 100, Price = 1.99},
            new Product { ProductID = 2, CategoryID = 1, ProductName = "Canada Dry", Quantity = 200, Price = 1.99},
            new Product { ProductID = 3, CategoryID = 2, ProductName = "Whole Wheat Bread", Quantity = 300, Price = 1.50},
            new Product { ProductID = 4, CategoryID = 2, ProductName = "White Bread", Quantity = 300, Price = 1.50}
        };

        public void AddProduct(Product product)
        {
            if(_products != null && _products.Count > 0)
            {
                var maxID = _products.Max(p => p.ProductID);
                product.ProductID = maxID + 1;
            }
            else
            {
                product.ProductID = 1;
            }
            _products ??= new List<Product>();
            _products.Add(product);
        }

        public void DeleteProduct(int productID)
        {
            var product = _products.FirstOrDefault(x => x.ProductID == productID);
            if (product == null)
            {
                return;
            }
            _products.Remove(product);
        }

        public Product? GetProductByID(int productID, bool loadCategory = false)
        {
            var product = _products.FirstOrDefault(x => x.ProductID == productID);
            if (product != null)
            {
                var prod = new Product
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    CategoryID = product.CategoryID,
                };

                if (loadCategory && prod.CategoryID.HasValue)
                {
                    prod.Category = viewSelectedCategoryUseCase.Execute(prod.CategoryID.Value); //CategoriesRepository.GetCategoryByID(prod.CategoryID.Value);
                }

                return prod;
            }

            return null;
        }

        public IEnumerable<Product> GetProducts(bool loadCategory)
        {
            {
                if (!loadCategory)
                {
                    return _products;
                }
                else
                {
                    if (_products != null && _products.Count() > 0)
                    {
                        _products.ForEach(product =>
                        {
                            if (product.CategoryID.HasValue)
                                product.Category = viewSelectedCategoryUseCase.Execute(product.CategoryID.Value);
                        });
                    }
                    return _products ?? new List<Product>();
                }
            }
        }

        public IEnumerable<Product> GetProductsByCategoryID(int categoryID)
        {
            var products = _products.Where(cat => cat.CategoryID == categoryID).ToList();
            return products;
        }

        public void UpdateProduct(int productID, Product product)
        {
            if (productID != product.ProductID)
            {
                return;
            }

            var productToUpdate = _products.FirstOrDefault(x => x.ProductID == productID);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryID = product.CategoryID;
            }
        }
    }
}
