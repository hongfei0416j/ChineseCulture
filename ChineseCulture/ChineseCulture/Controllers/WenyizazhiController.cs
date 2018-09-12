using ChineseCulture.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Controllers
{
    public class WenyizazhiController : Controller
    {
        // GET: Wenyizazhi
        public ActionResult Index()
        {
            HomePageBll homePageBll = new HomePageBll();
            var homePageModel = homePageBll.CreateWenyizazhiPageModel();
            return View(homePageModel);
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
    }
}