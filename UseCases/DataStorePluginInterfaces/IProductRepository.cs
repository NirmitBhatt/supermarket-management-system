using CoreBusinessEntities;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int productID);
        void UpdateProduct(int productID, Product product);
    }
}