﻿using Microsoft.AspNetCore.Mvc;

namespace Supermarket_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
