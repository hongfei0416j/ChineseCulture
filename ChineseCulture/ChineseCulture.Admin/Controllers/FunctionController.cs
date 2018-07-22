using ChineseCulture.Bll;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Admin.Controllers
{
    public class FunctionController : Controller
    {
        // GET: Function
        public ActionResult Index()
        {
            FunctionBll funBll = new FunctionBll();
            var adminLayoutViewModel = funBll.GetAllMenuFunction();
            return View(adminLayoutViewModel);
        }
    }
}