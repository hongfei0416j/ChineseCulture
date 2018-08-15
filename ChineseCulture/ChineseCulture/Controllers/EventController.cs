using ChineseCulture.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            HomePageBll homePageBll = new HomePageBll();
            var homePageModel = homePageBll.CreateEventPageModel();
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