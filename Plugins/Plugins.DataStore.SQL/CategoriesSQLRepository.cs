using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoriesSQLRepository : ICategoryRepository
    {
        private readonly MarketContext db;

        public CategoriesSQLRepository(MarketContext db)
        {
            this.db = db;
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryID)
        {
            var category = db.Categories.Find(categoryID);
            if (category == null)
            {
                return;
            }
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category? GetCategoryByID(int categoryID)
        {
            return db.Categories.Find(categoryID);
        }

        public void UpdateCategory(int categoryID, Category category)
        {
            if(categoryID != category.CategoryID)
            {
                return;
            }
            var cat = db.Categories.Find(categoryID);
            if (cat == null)
            {
                return;
            }
            cat.Name = category.Name;
            cat.Description = category.Description;
            db.SaveChanges();
        }
    }
}
