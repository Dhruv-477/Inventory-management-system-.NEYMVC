using Microsoft.AspNetCore.Mvc;
using myFirstapp.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace myFirstapp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string password)
        {
            if (name == "root" && password == "Admin@123") { 
                return RedirectToAction("Index", "Products");
            }

            TempData["WrongPass"] = "<h5 style = 'color: red; text-align: center;' > Wrong Password for admin!! </ h5 >";
            return View();
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
