using Microsoft.AspNetCore.Mvc;
using PizzeriaWebApp.Models;
using System.Diagnostics;

namespace PizzeriaWebApp.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult IndexUtente()
        {
            return View("IndexUtente");
        }

    }
}