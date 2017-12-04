using MVCDemo.Models;
using MVCDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class UsersController : Controller
    {

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                MVCModel ctx = new MVCModel();
                ctx.Users.Add(model);
                ctx.SaveChanges();
                TempData["Message"] = "کاربر با موفقیت افزوده شد";
                return View();
            }

            TempData["Message"] = "خطایی در مقادیر اطلاعاتی وجود دارد";
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                MVCModel ctx = new MVCModel();
                var user = ctx.Users
                    .Where(u => u.Username == model.Username && u.Password == model.Password)
                    .FirstOrDefault();
                if (user != null)//Authenticated User
                {
                    TempData["Message"] = $"{user.Name} {user.Family} شما با موفقیت به سایت وارد شدید";
                    //TODO
                    Session["UserId"] = user.Id;
                }
                else
                {
                    TempData["Message"] = "نام کاربری یا رمز عبور اشتباه است";
                    //TODO
                    Session["UserId"] = null;
                }
            }
            else
            {
                TempData["Message"] = "خطا در اطلاعات ورودی";
            }
            return View();
        }
    }
}