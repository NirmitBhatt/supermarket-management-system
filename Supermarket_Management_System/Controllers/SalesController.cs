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
    }
}
