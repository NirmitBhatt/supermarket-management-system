using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCases
{
    public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewSelectedProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Execute(int productID, bool loadCategory = false)
        {
            return productRepository.GetProductByID(productID, loadCategory);
        }
    }
}
