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

    }
}
