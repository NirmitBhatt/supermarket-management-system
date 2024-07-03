using Microsoft.AspNetCore.Mvc;
using Supermarket_Management_System.Models;
using Supermarket_Management_System.ViewModels;

namespace Supermarket_Management_System.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productID)
        {
            var product = ProductRepository.GetProductByID(productID);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if(ModelState.IsValid)
            {
                //return View(salesViewModel);
                var prod = ProductRepository.GetProductByID(salesViewModel.SelectedProductID);
                if(prod != null)
                {
                    TransactionRepository.AddTransaction(
                        "Cashier1",
                        salesViewModel.SelectedProductID,
                        prod.ProductName,
                        prod.Price.HasValue ? prod.Price.Value : 0,
                        prod.Quantity.HasValue ? prod.Quantity.Value : 0,
                        salesViewModel.QuantityToSell);

                    prod.Quantity -= salesViewModel.QuantityToSell;
                    ProductRepository.UpdateProduct(salesViewModel.SelectedProductID, prod);
                }
            }
            var product = ProductRepository.GetProductByID(salesViewModel.SelectedProductID);
            salesViewModel.SelectedCategoryID = (product?.CategoryID == null)? 0:product.CategoryID.Value;
            salesViewModel.Categories = CategoriesRepository.GetCategories();
            return View("Index", salesViewModel);
        }
    }
}
