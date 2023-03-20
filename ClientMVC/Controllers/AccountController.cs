using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Utility;

namespace ClientMVC.Controllers
{
    public class AccountController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        public IActionResult Login(string tokenMail)
        {
            //call api confirm token
            if (!string.IsNullOrEmpty(tokenMail))
            {
                try
                {
                    //call api confirm token mail
                    response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/ConfirmMail", new User { EmailConfirmationToken = tokenMail }).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        ViewBag.messConfirmMail = "Đã kích hoạt thành công, bạn có thể đăng nhập!";
                    }
                    else
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        ErrorApp errorApp = JsonConvert.DeserializeObject<ErrorApp>(responseString);
                        ViewBag.messConfirmMail = errorApp.Error;
                    }
                }
                catch { }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
                return View(userLogin);

            try
            {
                User userTemp = new()
                {
                    Email = userLogin.Email,
                    Password = userLogin.Password
                };
                //call api to login
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/Login", userTemp).Result;
                if (response.IsSuccessStatusCode)
                {
                    //get data
                    responseString = response.Content.ReadAsStringAsync().Result;
                    dynamic data = JObject.Parse(responseString);
                    User user = JsonConvert.DeserializeObject<User>(data.user.ToString());
                    string accessToken = data.access_Token;
                    //set session
                    HttpContext.Session.Set("IsLoggedIn", BitConverter.GetBytes(true));
                    HttpContext.Session.SetString("role", user.Role.Description);
                    HttpContext.Session.SetString("fullname", user.FullName);
                    HttpContext.Session.SetString("email", user.Email);
                    HttpContext.Session.SetInt32("id", user.Id);

                    //set token for client to call api at controller
                    GobalVariables.WebAPIClient.AddAuthorizationHeader(accessToken);

                    // set token into cookie
                    Response.Cookies.Append("access_token", accessToken, new CookieOptions
                    {
                        HttpOnly = false,
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Expires = DateTimeOffset.UtcNow.AddDays(1)
                    });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    ErrorApp errrApp = JsonConvert.DeserializeObject<ErrorApp>(responseString);
                    ViewBag.error = errrApp.Error;
                    return View(userLogin);
                }
            }
            catch { }

            ViewBag.error = ErrorContent.Error;
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
                return View(userRegister);

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
                //call api register user
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/PostUser", user).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.notification = "Đăng ký thành công, bạn hãy xác nhận mail!";
                }
                else
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    ErrorApp errorApp = JsonConvert.DeserializeObject<ErrorApp>(responseString);
                    ViewBag.mess = errorApp.Error;
                }
                return View();
            }
            catch { }

            ViewBag.mess = ErrorContent.Error;
            return View(userRegister);
        }

        public IActionResult Logout()
        {
            if (Request.Cookies["access_token"] != null)
            {
                Response.Cookies.Delete("access_token");
            }
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                //call api forgot password to take token forgot password
                response = GobalVariables.WebAPIClient.PostAsJsonAsync("Users/ForgotPassword", new User { Email = email }).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.notification = "Đã gửi mail xác nhận cập nhật mật khẩu thành công, bạn hãy vào mail xác nhận!";
                }
                else
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    ErrorApp errorApp = JsonConvert.DeserializeObject<ErrorApp>(responseString);
                    ViewBag.mess = errorApp.Error;
                }
            }
            catch 
            { 
                ViewBag.mess = ErrorContent.Error;
            }

            return View();
        }

        public IActionResult ResetPassword(string tokenPassword, string email)
        {
            ViewBag.TokenPassword = tokenPassword;
            return View(new UserRegister { Email = email });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(UserForgotPassword userInput, string tokenPassword)
        {
            if (!ModelState.IsValid)
                return View(userInput);

            try
            {
                User user = new()
                {
                    Email = userInput.Email,
                    Password = userInput.Password
                };

                //call api forgot password to take token forgot password
                response = GobalVariables.WebAPIClient.PostAsJsonAsync($"Users/ChangePassword/{tokenPassword}", user).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.notification = "Đã cập nhật mật khẩu thành công, bạn có thể đăng nhập!";
                }
                else
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    ErrorApp errorApp = JsonConvert.DeserializeObject<ErrorApp>(responseString);
                    ViewBag.mess = errorApp.Error;
                }
            }
            catch
            {
                ViewBag.mess = ErrorContent.Error;
            }

            return View();
        }
    }
}
