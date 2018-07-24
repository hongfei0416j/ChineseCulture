using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AdminIndexViewModel m = new AdminIndexViewModel();

            m.browser = Request.Browser.Browser;
            m.IpAddress = Request.UserHostAddress;
            m.serverName = Server.MachineName;

            return View(m);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}