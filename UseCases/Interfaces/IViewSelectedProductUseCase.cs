using CoreBusinessEntities;

namespace UseCases.ProductsUseCases
{
    public interface IViewSelectedProductUseCase
    {
        Product Execute(int productID, bool loadCategory = false);
    }
}