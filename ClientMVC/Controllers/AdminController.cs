using Microsoft.AspNetCore.Mvc;

namespace ClientMVC.Controllers
{
    [AdminSessionCheck]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
