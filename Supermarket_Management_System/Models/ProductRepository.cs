namespace Supermarket_Management_System.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { ProductID = 1, CategoryID = 1, ProductName = "Iced Tea", Quantity = 100, Price = 1.99},
            new Product { ProductID = 2, CategoryID = 1, ProductName = "Canada Dry", Quantity = 200, Price = 1.99},
            new Product { ProductID = 3, CategoryID = 2, ProductName = "Whole Wheat Bread", Quantity = 300, Price = 1.50},
            new Product { ProductID = 4, CategoryID = 2, ProductName = "White Bread", Quantity = 300, Price = 1.50}
        };

        public static List<Product> GetProducts(bool loadCategory = false)
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
                        if(product.CategoryID.HasValue)
                        product.Category = CategoriesRepository.GetCategoryByID(product.CategoryID.Value);
                    });
                }
                return _products ?? new List<Product>();
            }
        }

        public static Product? GetProductsByID(int productID, bool loadCategory = false)
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
                    prod.Category = CategoriesRepository.GetCategoryByID(prod.CategoryID.Value);
                }

                return prod;
            }
            
            return null;
        }

        public static void AddProduct(Product product)
        {
            var maxID = _products.Max(p => p.ProductID);
            product.ProductID = maxID + 1;
            _products.Add(product);
        }

        public static void UpdateProduct(int productID, Product product)
        {
            if (productID != product.ProductID) return;

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
