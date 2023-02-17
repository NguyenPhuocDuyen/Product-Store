using Microsoft.AspNetCore.Mvc;

namespace ClientMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //public IActionResult FoggotPassword()
        //{
        //    return View();
        //}
    }
}
