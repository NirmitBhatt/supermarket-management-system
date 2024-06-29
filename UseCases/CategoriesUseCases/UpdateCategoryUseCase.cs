using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class UpdateCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public UpdateCategoryUseCase(ICategoryRepository categoryRepository) 
        {
            this.categoryRepository = categoryRepository;
        }

        public void Execute(int categoryID, Category category)
        {
            categoryRepository.UpdateCategory(categoryID, category);
        }
    }
}
