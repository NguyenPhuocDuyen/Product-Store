﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Utility;

namespace ClientMVC.Controllers
{
    [SessionCheck]
    public class CustomerController : Controller
    {
        HttpResponseMessage response;
        string responseString;

        public IActionResult Cart()
        {
            try
            {
                //call api get cart of user
                response = GobalVariables.WebAPIClient.GetAsync($"Carts/GetCartsUser").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<Cart> products = JsonConvert.DeserializeObject<List<Cart>>(responseString);
                    return View(products);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details()
        {
            try
            {
                //call api get user info
                response = GobalVariables.WebAPIClient.GetAsync("Users/GetUserInfo").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    User user = JsonConvert.DeserializeObject<User>(responseString);
                    user.Password = "";
                    return View(user);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult OrderDetail(int id)
        {
            try
            {
                //call api get OrderDetails by order id
                response = GobalVariables.WebAPIClient.GetAsync($"OrderDetails/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    responseString = response.Content.ReadAsStringAsync().Result;
                    List<OrderDetail> orderDetail = JsonConvert.DeserializeObject<List<OrderDetail>>(responseString);
                    ViewBag.Order = orderDetail[0].Order;
                    return View(orderDetail);
                }
            }
            catch { }

            return RedirectToAction("Index", "Home");
        }
    }
}
