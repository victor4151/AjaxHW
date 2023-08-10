using Microsoft.AspNetCore.Mvc;
using prjAjaxhomework.Models;
using System.Diagnostics;

namespace prjAjaxhomework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()//HW1
        {
            return View();
        }
        public IActionResult Register()//HW3 && HW5
        {
            return View();
        }
        public IActionResult City()//HW4
        {
            return View();
        }
        public IActionResult Fetch()//HW6
        {
            return View();
        }
        public IActionResult Travel()//HW2
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}