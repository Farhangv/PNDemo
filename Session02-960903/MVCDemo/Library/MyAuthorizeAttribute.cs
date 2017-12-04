using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Library
{
    public class MyAuthorizeAttribute:ActionFilterAttribute
    {
        public MyAuthorizeAttribute(params string[] roles)
        {
            Roles = roles;
        }
        private string[] Roles { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userid = HttpContext.Current.Session["UserId"];
            if (userid != null)//Authenticated
            {
                MVCModel ctx = new MVCModel();
                var user = ctx.Users.Find(Convert.ToInt32(userid));
                var userRole = user.Role;
                if (Roles != null)
                {
                    bool isAuthorized = false;
                    foreach (var role in Roles)
                    {
                        if (userRole.ToLower() == role.ToLower())
                            isAuthorized = true;
                    }

                    if (!isAuthorized)
                    {
                        filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    }
                }
            }
            else
            {
                filterContext.Controller.TempData.Add("Message", "شما تا قبل از ورود اجازه دسترسی به این صفحه را ندارید");
                filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary
                        {
                            { "controller", "Users" },
                            { "action", "Login" }
                        }
                    );
            }
        }
    }
}