using CoreBusinessEntities;

namespace UseCases.ProductsUseCases
{
    public interface IViewProductsInCategoryUseCase
    {
        IEnumerable<Product> Execute(int categoryID);
    }
}