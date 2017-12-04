using MVCDemo.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class AdminPanelController : Controller
    {
        [MyAuthorize("admin", "normaluser")]
        public ActionResult Index()
        {
            return View();
        }
    }
}