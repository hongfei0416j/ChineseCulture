using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
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