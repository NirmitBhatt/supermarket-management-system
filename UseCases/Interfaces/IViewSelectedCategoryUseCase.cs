using CoreBusinessEntities;

namespace UseCases.CategoriesUseCases
{
    public interface IViewSelectedCategoryUseCase
    {
        Category? Execute(int categoryID);
    }
}