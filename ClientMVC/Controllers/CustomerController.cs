using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ClientMVC.Controllers
{
    [SessionCheck]
    public class CustomerController : Controller
    {

        HttpResponseMessage response;
        string responseString;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync($"Carts/GetCartsUser").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Cart> products = JsonConvert.DeserializeObject<List<Cart>>(responseString);
                    return View(products);
                }
            }
            catch {}

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details()
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Users/GetUserInfo").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    User user = JsonConvert.DeserializeObject<User>(responseString);
                    return View(user);
                }
            } catch { }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult OrderProducts()
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Orders/OrderProducts").Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Cart", "Customer");
                }
            } catch { }

            return RedirectToAction("Index", "Home");
        }
    }
}
