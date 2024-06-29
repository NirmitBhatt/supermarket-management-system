namespace Supermarket_Management_System.Models
{
    public static class CategoriesRepository
    {
        public static List<Category> _categories = new List<Category>()
        {
            new Category {CategoryID = 1, Name = "Beverage", Description = "Beverage"},
            new Category {CategoryID = 2, Name = "Bakery", Description = "Bakery"},
            new Category {CategoryID = 3, Name ="Meat", Description = "Meat"}
        };

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryByID(int categoryID)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryID == categoryID);
            if (category == null)
            {
                return null;
            }
            return new Category
            {
                CategoryID = category.CategoryID,
                Name = category.Name,
                Description = category.Description,
            };
        }

        public static void AddCategory(Category category)
        {
            if(_categories != null && _categories.Count > 0)
            {
                var maxID = _categories.Max(c => c.CategoryID);
                category.CategoryID = maxID + 1;
            }
            else
            {
                category.CategoryID = 1;
            }
            _categories ??= new List<Category>();
            _categories.Add(category);
        }

        public static void UpdateCategory(int categoryID, Category category)
        {
            if (categoryID != category.CategoryID)
            {
                return;
            }

            var categoryToUpdate = _categories.FirstOrDefault(c => c.CategoryID == categoryID);
            if (categoryToUpdate == null)
            {
                return;
            }
            categoryToUpdate.CategoryID = category.CategoryID;
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
        }

        public static void DeleteCategory(int categoryID)
        {
            var category = _categories.FirstOrDefault(category => category.CategoryID == categoryID);
            if (category == null) return;
            _categories.Remove(category);

        }
    }
}
