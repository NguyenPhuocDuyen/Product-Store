using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using Newtonsoft.Json;
using System;
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
        public IActionResult Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.error = "Input blank or email not correct!";
                return View(userLogin);
            }

            try
            {
                User userTemp = new()
                {
                    Email = userLogin.Email,
                    Password = userLogin.Password
                };
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/Login", userTemp).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    User user = JsonConvert.DeserializeObject<User>(responseString);

                    HttpContext.Session.Set("IsLoggedIn", BitConverter.GetBytes(true));

                    HttpContext.Session.SetString("role", user.Role.Description);
                    HttpContext.Session.SetInt32("userId", user.Id);
                    HttpContext.Session.SetString("email", user.Email);
                    HttpContext.Session.SetString("fullname", user.FullName);
                    HttpContext.Session.SetString("phone", user.Phone);

                    //set token by password becasue password = token return from api
                    HttpContext.Session.SetString("token", user.Password);
                    GobalVariables.WebAPIClient.AddAuthorizationHeader(user.Password);

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
                return View(userRegister);
            }

            try
            {
                User user = new()
                {
                    Email = userRegister.Email,
                    FullName = userRegister.FullName,
                    Phone = userRegister.Phone,
                    Password = userRegister.Password,
                    Address = userRegister.Address
                };
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/PostUser", user).Result;
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
    }
}
