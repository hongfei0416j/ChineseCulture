using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Controllers
{
    public class PartinalController : Controller
    {
        // GET: Partinal
        public ActionResult HomePageMenu()
        {
            return View();
        }
        public ActionResult HomePageCategoryMenu()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult FriendLink()
        {
            return View();
        }
    }
}