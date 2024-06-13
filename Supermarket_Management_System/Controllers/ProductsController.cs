using Microsoft.AspNetCore.Mvc;
using Supermarket_Management_System.Models;

namespace Supermarket_Management_System.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductRepository.GetProducts(loadCategory: true);
            return View(products);
        }
    }
}
