using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;

namespace ClientMVC
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (!session.TryGetValue("IsLoggedIn", out byte[] value))
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
            else if (!BitConverter.ToBoolean(value, 0))
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class AdminSessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            var role = session.GetString("role");
            if (role is null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
            else
            {
                if (!role.Contains("Admin"))
                {
                    filterContext.Result = new RedirectResult("/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
