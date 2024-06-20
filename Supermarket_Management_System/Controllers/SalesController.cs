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
                Categories = CategoriesRepository.GetCategory()
            };
            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productID)
        {
            var product = ProductRepository.GetProductsByID(productID);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if(ModelState.IsValid)
            {
                //return View(salesViewModel);
                var prod = ProductRepository.GetProductsByID(salesViewModel.SelectedProductID);
                if(prod != null)
                {
                    prod.Quantity -= salesViewModel.QuantityToSell;
                    ProductRepository.UpdateProduct(salesViewModel.SelectedProductID, prod);
                }
            }
            var product = ProductRepository.GetProductsByID(salesViewModel.SelectedProductID);
            salesViewModel.SelectedCategoryID = (product?.CategoryID == null)? 0:product.CategoryID.Value;
            salesViewModel.Categories = CategoriesRepository.GetCategory();
            return View("Index", salesViewModel);
        }
    }
}
