using CoreBusinessEntities;

namespace UseCases.CategoriesUseCases
{
    public interface IUpdateCategoryUseCase
    {
        void Execute(int categoryID, Category category);
    }
}