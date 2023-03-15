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
        HttpResponseMessage response;
        string responseString;

        public IActionResult Index()
        {
            try
            {
                //get list product
                response = GobalVariables.WebAPIClient.GetAsync("Products/GetProducts").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                    products = products.Where(x=>x.Amount > 0).ToList();

                    //get top product sale
                    response = GobalVariables.WebAPIClient.GetAsync("Products/TopSaleProductId").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        List<int> idProducts = JsonConvert.DeserializeObject<List<int>>(responseString);

                        ViewBag.ProductsTopSale = products.Where(x => idProducts.Contains(x.Id)).ToList();
                    }
                    //return list 4 product new
                    return View(products.OrderByDescending(x => x.CreateAt).Take(4).ToList());
                }
            }
            catch { }

            return View();
        }
    }
}
