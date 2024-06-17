using Microsoft.AspNetCore.Mvc;
using Supermarket_Management_System.Models;

namespace Supermarket_Management_System.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategory();
            return View(categories);
        }

        public IActionResult Edit([FromRoute] int? id)
        {
            ViewBag.ActionName = "edit";
            var category = CategoriesRepository.GetCategoryByID(id.HasValue?id.Value:0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryID, category);
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
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ActionName = "add";
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
