using CoreBusinessEntities;

namespace UseCases.ProductsUseCases
{
    public interface IUpdateProductUseCase
    {
        void Execute(int productID, Product product);
    }
}