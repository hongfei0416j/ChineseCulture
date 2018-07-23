using ChineseCulture.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Admin.Controllers
{
    public class PartinalController : Controller
    {
        // GET: Partinal
        public ActionResult HeaderTop()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult LeftMenu()
        {

            FunctionBll funBll = new FunctionBll();
            var adminLayoutViewModel = funBll.GetAllMenuFunction();
            return View(adminLayoutViewModel);
        }
        public ActionResult ContentNav()
        {
            return View();
        }
    }
}