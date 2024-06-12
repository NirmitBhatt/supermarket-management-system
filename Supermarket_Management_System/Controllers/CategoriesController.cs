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
            return View(category); 
        }

        public IActionResult Add()
        {
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
            return View(category);
        }
    }
}
