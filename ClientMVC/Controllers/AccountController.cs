using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;

namespace ClientMVC.Controllers
{
    public class AccountController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User userLogin)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Input blank or email not correct!";
                return View();
            }

            try
            {
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/Login", userLogin).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    User user = JsonConvert.DeserializeObject<User>(responseString);

                    HttpContext.Session.Set("IsLoggedIn", BitConverter.GetBytes(true));

                    HttpContext.Session.SetString("role", user.Role.Description);
                    HttpContext.Session.SetInt32("userId", user.Id);
                    HttpContext.Session.SetString("email", user.Email);

                    return RedirectToAction("Index", "Home");
                }
            }
            catch { }

            ViewBag.error = "Email or password not correct!";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Input blank or Email not correct!";
                return View();
            }

            try
            {
                User user = userRegister;
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users", user).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            catch { }

            ViewBag.error = "Email exist or confirm password not correct!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //public IActionResult FoggotPassword()
        //{
        //    return View();
        //}
    }
}
