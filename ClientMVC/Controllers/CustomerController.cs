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
            return View();
        }
    }
}
