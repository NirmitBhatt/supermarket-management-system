using CoreBusinessEntities;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(int categoryID);
        void UpdateCategory(int categoryID, Category category);
    }
}