using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCases
{
    public class ViewProductsInCategoryUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductsInCategoryUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(int categoryID)
        {
            return productRepository.GetProductsByCategoryID(categoryID);
        }
    }
}
