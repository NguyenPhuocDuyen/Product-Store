using Microsoft.AspNetCore.Mvc;
using Models;

namespace ClientMVC.Controllers
{
    [AdminSessionCheck]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
