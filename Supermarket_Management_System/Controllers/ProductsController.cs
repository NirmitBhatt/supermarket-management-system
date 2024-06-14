using Microsoft.AspNetCore.Mvc;
using Supermarket_Management_System.Models;
using Supermarket_Management_System.ViewModels;

namespace Supermarket_Management_System.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductRepository.GetProducts(loadCategory: true);
            return View(products);
        }

        public IActionResult Add()
        {
            var productViewModel = new ProductViewModel()
            {
                Categories = CategoriesRepository.GetCategory()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (product != null)
            {
                ProductRepository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
