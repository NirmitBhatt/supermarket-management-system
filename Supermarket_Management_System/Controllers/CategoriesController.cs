using CoreBusinessEntities;
using Microsoft.AspNetCore.Mvc;
//using Supermarket_Management_System.Models;
using UseCases.CategoriesUseCases;

namespace Supermarket_Management_System.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IAddCategoryUseCase addCategoryUseCase;
        private readonly IDeleteCategoryUseCase deleteCategoryUseCase;
        private readonly IUpdateCategoryUseCase updateCategoryUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;

        public CategoriesController(IAddCategoryUseCase addCategoryUseCase,
            IDeleteCategoryUseCase deleteCategoryUseCase,
            IUpdateCategoryUseCase updateCategoryUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedCategoryUseCase viewSelectedCategoryUseCase)
        {
            this.addCategoryUseCase = addCategoryUseCase;
            this.deleteCategoryUseCase = deleteCategoryUseCase;
            this.updateCategoryUseCase = updateCategoryUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
        }
        public IActionResult Index()
        {
            var categories = viewCategoriesUseCase.Execute();
            return View(categories);
        }

        public IActionResult Edit([FromRoute] int? id)
        {
            ViewBag.ActionName = "edit";
            var category = viewSelectedCategoryUseCase.Execute(id.HasValue?id.Value:0);//CategoriesRepository.GetCategoryByID(id.HasValue?id.Value:0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                updateCategoryUseCase.Execute(category.CategoryID, category);//CategoriesRepository.UpdateCategory(category.CategoryID, category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "edit";
            return View(category); 
        }

        public IActionResult Add()
        {
            ViewBag.ActionName = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm]Category category)
        {
            if (ModelState.IsValid)
            {
                addCategoryUseCase.Execute(category);//CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "add";
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            deleteCategoryUseCase.Execute(id);//CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
