﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Utility;

namespace ClientMVC.Controllers
{
    public class ShopController : Controller
    {
        HttpResponseMessage response;
        string responseString;

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

                //get product list
                response = GobalVariables.WebAPIClient.GetAsync("Products/GetProducts").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                    products = products.Where(x => x.Amount > 0).ToList();

                    //check search by name and price
                    if (searchContent is not null)
                    {
                        searchContent = RemoveDiacriticsAndSpecialCharacters(searchContent);

                        products = products.Where(x
                            => RemoveDiacriticsAndSpecialCharacters(x.Title).Contains(searchContent)
                            || RemoveDiacriticsAndSpecialCharacters(x.Category.Description).Contains(searchContent)
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
                    ViewBag.TotalProduct = products.Count;
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
                //get total user 
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
                    List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(responseString);
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

                //get % happy
                response = GobalVariables.WebAPIClient.GetAsync("Reviews/GetReviewsOfProduct").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Review> reviews = JsonConvert.DeserializeObject<List<Review>>(responseString);
                    double? averageRate = reviews.Average(x => x.Rate);
                    if (reviews.Count == 0)
                    {
                        averageRate = 5;
                    }
                    int percentHappiness = (int)Math.Round((decimal)(averageRate / 5 * 100));
                    ViewBag.PercentHappiness = percentHappiness;
                }

            }
            catch { }

            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            try
            {
                //check user bought this product to display form review of this product
                int? userId = HttpContext.Session.GetInt32("id");
                bool isBought = false;
                if (userId is not null)
                {
                    response = GobalVariables.WebAPIClient.GetAsync("OrderDetails/GetOrderDetailReceived").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                        List<OrderDetail> orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(responseString);
                        {
                            foreach (var item in orderDetails)
                            {
                                if (item.Order.UserId == userId)
                                {
                                    isBought = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                ViewBag.IsBought = isBought;

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
                            .OrderByDescending(x => x.UpdateAt)
                            .Take(4).ToList();
                        ViewBag.Products = products;
                    }

                    return View(product);
                }
            }
            catch { }

            return RedirectToAction("Index");
        }

        public IActionResult Contact()
        {
            return View();
        }

        // Phương thức chuyển đổi chữ có dấu thành không dấu bỏ ký tự đặc biệt
        private static string RemoveDiacriticsAndSpecialCharacters(string text)
        {
            string normalized = text.ToLower().Trim().Normalize(NormalizationForm.FormKD);
            Regex regex = new("[^\\p{L}\\p{Nd}\\s#@!&$%]");
            string result = regex.Replace(normalized, "");

            // Replace "đ" with "d"
            result = result.Replace("đ", "d");

            return result;
        }
    }
}
