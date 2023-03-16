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
                        ViewBag.mess = "Thêm sản phẩm thành công!";
                        return View();
                        //return RedirectToAction("Index", "Shop");
                    }
                }
                catch { }
            }
            ViewBag.mess = "Thêm sản phẩm thất bại!";
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

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product, IFormFile ThumbnailFile)
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
                    response = GobalVariables.WebAPIClient.PostAsJsonAsync($"Products/UpdateProduct/{product.Id}", product).Result;
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
        public IActionResult Dashboard()
        {
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
