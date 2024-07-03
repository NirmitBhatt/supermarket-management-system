using CoreBusinessEntities;

namespace UseCases.ProductsUseCases
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute(bool loadCategory = false);
    }
}