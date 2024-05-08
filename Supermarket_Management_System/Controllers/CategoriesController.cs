using Microsoft.AspNetCore.Mvc;

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
            if(id.HasValue)
            {
                return new ContentResult { Content = "The id of this product is: " + id.ToString() };
            }
            else
            {
                return new ContentResult { Content = "Null content" };
            }
            
        }
    }
}
