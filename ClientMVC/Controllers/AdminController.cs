using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ClientMVC.Controllers
{
    [AdminSessionCheck]
    public class AdminController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Orders() 
        //{
        //    try
        //    {
        //        response = GobalVariables.WebAPIClient.GetAsync("Orders/GetOrdersOfUser").Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            responseString = response.Content.ReadAsStringAsync().Result;
        //            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(responseString);
        //            return View(orders);
        //        }
        //    }
        //    catch { }

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
