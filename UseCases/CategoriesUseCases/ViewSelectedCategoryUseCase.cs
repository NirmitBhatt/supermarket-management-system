using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewSelectedCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Category? Execute(int categoryID)
        {
            return categoryRepository.GetCategoryByID(categoryID);
        }
    }
}
