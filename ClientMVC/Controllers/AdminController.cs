using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClientMVC.Controllers
{
    [AdminSessionCheck]
    public class AdminController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        [HttpGet]
        public IActionResult CreateProduct()
        {
            try
            {
                //get Category list
                response = GobalVariables.WebAPIClient.GetAsync("Categorys").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(responseString);
                    ViewBag.CategoryId = new SelectList(categories, "Id", "Description");
                }
            } 
            catch { }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile ThumbnailFile)
        {
            if (ModelState.IsValid)
            {
                if (ThumbnailFile != null && ThumbnailFile.Length > 0)
                {
                    var fileName = GetUniqueFileName(ThumbnailFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ThumbnailFile.CopyToAsync(stream);
                    }
                    product.Thumbnail = "/images/products/" + fileName;
                }

                // call api save product
                try
                {
                    response = GobalVariables.WebAPIClient.PostAsJsonAsync("Products/AddProduct", product).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Shop");
                    }
                }
                catch { }
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            try
            {
                //get Category list
                response = GobalVariables.WebAPIClient.GetAsync("Categorys").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(responseString);
                    ViewBag.CategoryId = new SelectList(categories, "Id", "Description");
                }

                //get product
                response = GobalVariables.WebAPIClient.GetAsync($"Products/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    Product product = JsonConvert.DeserializeObject<Product>(responseString);
                    return View(product);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateProduct(Product product, IFormFile ThumbnailFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (ThumbnailFile != null && ThumbnailFile.Length > 0)
        //        {
        //            var fileName = GetUniqueFileName(ThumbnailFile.FileName);
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products", fileName);

        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await ThumbnailFile.CopyToAsync(stream);
        //            }
        //            product.Thumbnail = "/images/products/" + fileName;
        //        }

        //        // call api save product
        //        try
        //        {
        //            response = GobalVariables.WebAPIClient.PostAsJsonAsync("Products/AddProduct", product).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                return RedirectToAction("Index", "Shop");
        //            }
        //        }
        //        catch { }
        //    }

        //    return View(product);
        //}

        [HttpGet]
        public IActionResult Dashboard()
        {
            try
            {
                //get Category list
                response = GobalVariables.WebAPIClient.GetAsync("Users/GetUsers").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(responseString);
                    ViewBag.ListUser = users;
                }

                //get order list
                response = GobalVariables.WebAPIClient.GetAsync("Orders/GetOrdersOfUser").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(responseString);
                    ViewBag.ListOrder = orders;
                }

                //get product list
                response = GobalVariables.WebAPIClient.GetAsync("Products/GetProducts").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                    ViewBag.ListProduct = products;
                }
            }
            catch { }

            return View();
        }

        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }
    }
}
