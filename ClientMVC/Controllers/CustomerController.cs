using Microsoft.AspNetCore.Mvc;

namespace ClientMVC.Controllers
{
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
    }
}
