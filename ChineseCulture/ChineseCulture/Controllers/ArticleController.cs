using ChineseCulture.Bll;
using ChineseCulture.Model;
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
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel = articlePageBll.CreateArticleListModel();
            return View(articlePageViewModel);
        }
        public ActionResult Detail(int id)
        {
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel =articlePageBll.CreateArticleDetailModel(id);

            return View(articlePageViewModel);
        }
    }
}