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
            ViewBag.ActionName = "add";
            var productViewModel = new ProductViewModel()
            {
                Categories = CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "add";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Edit(int productID)
        {
            ViewBag.ActionName = "edit";
            var productViewModel = new ProductViewModel()
            {
                Categories = CategoriesRepository.GetCategories(),
                Product = ProductRepository.GetProductByID(productID) ?? new Product()
            };
            //var product = ProductRepository.GetProductsByID(productID, loadCategory: true);
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.UpdateProduct(productViewModel.Product.ProductID, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "edit";
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Delete(int productID)
        {
            ProductRepository.DeleteProduct(productID);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryID)
        {
            var products = ProductRepository.GetProductsByCategoryID(categoryID);
            return PartialView("_ProductsByCategoryID", products);
        }
    }
}
