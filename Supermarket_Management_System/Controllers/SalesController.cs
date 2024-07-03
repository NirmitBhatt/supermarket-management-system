using Microsoft.AspNetCore.Mvc;
using CoreBusinessEntities;
using Supermarket_Management_System.ViewModels;
using UseCases.CategoriesUseCases;
using UseCases.ProductsUseCases;
using UseCases.TransactionsUseCases;

namespace Supermarket_Management_System.Controllers
{
    public class SalesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IUpdateProductUseCase updateProductUseCase;
        private readonly IAddTransactionUseCase addTransactionUseCase;

        public SalesController(IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            IUpdateProductUseCase updateProductUseCase,
            IAddTransactionUseCase addTransactionUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.updateProductUseCase = updateProductUseCase;
            this.addTransactionUseCase = addTransactionUseCase;
        }
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };
            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productID)
        {
            var product = viewSelectedProductUseCase.Execute(productID);//ProductRepository.GetProductByID(productID);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if(ModelState.IsValid)
            {
                //return View(salesViewModel);
                var prod = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductID);//ProductRepository.GetProductByID(salesViewModel.SelectedProductID);
                if(prod != null)
                {
                    addTransactionUseCase.Execute(
                        "Cashier1",
                        salesViewModel.SelectedProductID,
                        prod.ProductName,
                        prod.Price.HasValue ? prod.Price.Value : 0,
                        prod.Quantity.HasValue ? prod.Quantity.Value : 0,
                        salesViewModel.QuantityToSell);

                    prod.Quantity -= salesViewModel.QuantityToSell;
                    updateProductUseCase.Execute(salesViewModel.SelectedProductID, prod);//ProductRepository.UpdateProduct(salesViewModel.SelectedProductID, prod);
                }
            }
            var product = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductID);
            salesViewModel.SelectedCategoryID = (product?.CategoryID == null)? 0:product.CategoryID.Value;
            salesViewModel.Categories = viewCategoriesUseCase.Execute();//CategoriesRepository.GetCategories();
            return View("Index", salesViewModel);
        }
    }
}
