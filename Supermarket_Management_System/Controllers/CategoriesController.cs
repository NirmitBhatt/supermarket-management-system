using Microsoft.AspNetCore.Mvc;
using Supermarket_Management_System.Models;

namespace Supermarket_Management_System.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var category = new Category {CategoryID = id.HasValue?id.Value:0 };

            return View(category);
            //if(id.HasValue)
            //{
            //    return new ContentResult { Content = "The id of this product is: " + id.ToString() };
            //}
            //else
            //{
            //    return new ContentResult { Content = "Null content" };
            //}
            
        }
    }
}
