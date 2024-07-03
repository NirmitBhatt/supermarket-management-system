using CoreBusinessEntities;
using Microsoft.AspNetCore.Mvc;
//using Supermarket_Management_System.Models;
using Supermarket_Management_System.ViewModels;
using UseCases.CategoriesUseCases;
using UseCases.ProductsUseCases;

namespace Supermarket_Management_System.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAddProductUseCase addProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IUpdateProductUseCase updateProductUseCase;
        private readonly IViewProductsInCategoryUseCase viewProductsInCategoryUseCase;
        private readonly IViewProductsUseCase viewProductsUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;

        public ProductsController(IAddProductUseCase addProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,
            IUpdateProductUseCase updateProductUseCase,
            IViewProductsInCategoryUseCase viewProductsInCategoryUseCase,
            IViewProductsUseCase viewProductsUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase)
        {
            this.addProductUseCase = addProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.updateProductUseCase = updateProductUseCase;
            this.viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;
            this.viewProductsUseCase = viewProductsUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
        }
        public IActionResult Index()
        {
            var products = viewProductsUseCase.Execute(loadCategory: true);//ProductRepository.GetProducts(loadCategory: true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.ActionName = "add";
            var productViewModel = new ProductViewModel()
            {
                Categories = viewCategoriesUseCase.Execute()//CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                addProductUseCase.Execute(productViewModel.Product); //ProductRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "add";
            productViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        public IActionResult Edit(int productID)
        {
            ViewBag.ActionName = "edit";
            var productViewModel = new ProductViewModel()
            {
                Categories = viewCategoriesUseCase.Execute(),
                Product = viewSelectedProductUseCase.Execute(productID) //ProductRepository.GetProductByID(productID) ?? new Product()
            };
            //var product = ProductRepository.GetProductsByID(productID, loadCategory: true);
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                updateProductUseCase.Execute(productViewModel.Product.ProductID, productViewModel.Product);//ProductRepository.UpdateProduct(productViewModel.Product.ProductID, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "edit";
            productViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        public IActionResult Delete(int productID)
        {
            deleteProductUseCase.Execute(productID);//ProductRepository.DeleteProduct(productID);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryID)
        {
            var products = viewProductsInCategoryUseCase.Execute(categoryID); //ProductRepository.GetProductsByCategoryID(categoryID);
            return PartialView("_ProductsByCategoryID", products);
        }
    }
}
