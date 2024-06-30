using CoreBusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCases
{
    public class UpdateProductUseCase
    {
        private readonly IProductRepository productRepository;

        public UpdateProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(int productID, Product product)
        {
            productRepository.UpdateProduct(productID, product);
        }
    }
}
