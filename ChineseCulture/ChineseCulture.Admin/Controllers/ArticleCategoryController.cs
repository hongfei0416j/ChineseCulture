using ChineseCulture.Bll;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Admin.Controllers
{
    public class ArticleCategoryController : Controller
    {
        // GET: ArticleCategory
        public ActionResult Index()
        {
            ArticleCategoryBll acBll = new ArticleCategoryBll();
            var cateGoryList = acBll.GetAllCategory(0);
            return View(cateGoryList);
        }
        public ActionResult Add(ArticleCategory ac)
        {
            ArticleCategoryBll acBll = new ArticleCategoryBll();
            acBll.AddArticleCategory(ac);
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}