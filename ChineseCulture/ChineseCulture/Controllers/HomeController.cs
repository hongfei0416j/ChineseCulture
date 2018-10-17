using ChineseCulture.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomePageBll homePageBll = new HomePageBll();
            var homePageModel = homePageBll.CreateHomePageModel();
            return View(homePageModel);
        }
        public ActionResult Reg()
        {
            string telphone = "";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}