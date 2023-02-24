using Microsoft.AspNetCore.Mvc;

namespace ClientMVC.Controllers
{
    [SessionCheck]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Details() 
        {
            return View();
        }
    }
}
