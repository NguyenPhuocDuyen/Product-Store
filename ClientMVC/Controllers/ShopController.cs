using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using Utility;

namespace ClientMVC.Controllers
{
    public class ShopController : Controller
    {
        HttpResponseMessage response;
        HttpRequestMessage request;
        string responseString;
        //string content;

        public IActionResult Index(string searchContent, int min, int max,
            int sort_order = 1, int pageIndex = 1)
        {
            List<Product> products = new();
            try
            {
                //get Category list
                response = GobalVariables.WebAPIClient.GetAsync("Categorys").Result;
                List<Category> categories = new();
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    categories = JsonConvert.DeserializeObject<List<Category>>(responseString);
                    ViewBag.Categories = categories;
                }

                //get sort price list
                response = GobalVariables.WebAPIClient.GetAsync("FilterPrices").Result;
                List<int> filterPrices = new();
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    filterPrices = JsonConvert.DeserializeObject<List<int>>(responseString);
                    ViewBag.FilterPrices = filterPrices;
                }

                //get product list
                response = GobalVariables.WebAPIClient.GetAsync("Products/GetProducts").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<Product>>(responseString);

                    //check search by name and price
                    if (searchContent is not null)
                    {
                        if (sort_order != 0)
                        {
                            searchContent = HttpUtility.UrlDecode(searchContent);
                        }

                        searchContent = HttpUtility.HtmlDecode(searchContent);
                        //content = searchContent;
                        searchContent = searchContent.ToLower().Trim();
                        products = products.Where(x
                            => x.Title.ToLower().Trim().Contains(searchContent)
                            || x.Category.Description.ToLower().Trim().Contains(searchContent)
                            ).ToList();
                    }
                    //filter
                    if (min < max)
                    {
                        products = products.Where(x => x.RecentPrice >= min
                                        && x.RecentPrice <= max).ToList();
                    }
                    //sort price
                    if (sort_order == 2)
                    {
                        products = products.OrderBy(x => x.RecentPrice).ToList();
                    }
                    else if (sort_order == 3)
                    {
                        products = products.OrderByDescending(x => x.RecentPrice).ToList();
                    }
                    //set var binding
                    ViewBag.searchContent = searchContent;
                    ViewBag.min = min;
                    ViewBag.max = max;
                    ViewBag.sort_order = sort_order;
                    ViewBag.TotalProduct = products.Count();
                    //paging
                    var pageSize = 12;
                    var PagingListProduct = PaginatedList<Product>.CreateAsync(
                        products, pageIndex, pageSize);

                    return View(PagingListProduct);
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult About()
        {
            try
            {
                //get Category list
                response = GobalVariables.WebAPIClient.GetAsync("Users/TotalUser").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    int totalUser = JsonConvert.DeserializeObject<int>(responseString);
                    ViewBag.TotalUser = totalUser;
                }

                //get Category list
                response = GobalVariables.WebAPIClient.GetAsync("Categorys").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Category>  categories = JsonConvert.DeserializeObject<List<Category>>(responseString);
                    ViewBag.TotalCategory = categories.Count;
                }

                //get product list
                response = GobalVariables.WebAPIClient.GetAsync("Products/GetProducts").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                    ViewBag.TotalProduct = products.Count;
                }
            }
            catch { }

            return View();
        }

        //public IActionResult Blog()
        //{
        //    return View();
        //}

        //public IActionResult BlogDetail()
        //{
        //    return View();
        //}

        public IActionResult ProductDetail(int id)
        {
            try
            {
                // Get product from database based on ID
                response = GobalVariables.WebAPIClient.GetAsync($"Products/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Product product = JsonConvert.DeserializeObject<Product>(responseString);

                    //get Related Product list
                    response = GobalVariables.WebAPIClient.GetAsync("Products/GetProducts").Result;
                    List<Product> products = new();
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        products = products.Where(x 
                            => x.Category.Description.Equals(product.Category.Description)
                            || x.Title.ToLower().Contains(product.Title.ToLower()))
                            .OrderByDescending(x=>x.UpdateAt)
                            .Take(4).ToList();
                        ViewBag.Products = products;
                    }

                    return View(product);
                }
            }
            catch { }

            return RedirectToAction("Index");
        }

        //public IActionResult CheckOut()
        //{
        //    return View();
        //}

        public IActionResult Contact()
        {
            return View();
        }
    }
}
