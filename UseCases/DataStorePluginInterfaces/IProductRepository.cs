using CoreBusinessEntities;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int productID);
        Product GetProductByID(int productID, bool loadCategory = false);
        IEnumerable<Product> GetProducts(bool loadCategory);
        IEnumerable<Product> GetProductsByCategoryID(int categoryID);
        void UpdateProduct(int productID, Product product);
    }
}