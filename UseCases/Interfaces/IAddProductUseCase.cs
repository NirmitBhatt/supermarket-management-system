using CoreBusinessEntities;

namespace UseCases.ProductsUseCases
{
    public interface IAddProductUseCase
    {
        void Execute(Product product);
    }
}