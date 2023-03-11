using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Models;

namespace ClientMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        HttpResponseMessage response;
        string responseString;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                response = GobalVariables.WebAPIClient.GetAsync("Products/GetProducts").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);

                    response = GobalVariables.WebAPIClient.GetAsync("Products/TopSaleProductId").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        List<int> idProducts = JsonConvert.DeserializeObject<List<int>>(responseString);

                        ViewBag.ProductsTopSale = products.Where(x => idProducts.Contains(x.Id)).ToList();
                    }

                    return View(products.OrderByDescending(x => x.CreateAt).Take(4).ToList());
                }
            }
            catch { }

            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
