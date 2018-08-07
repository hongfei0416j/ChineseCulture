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
        public ActionResult List(int page_index=0)
        {
            if (page_index==null|| page_index<0)
            {
                page_index = 0;
            }
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel = articlePageBll.CreateArticleListModel();
            return View(articlePageViewModel);
        }
        public ActionResult Detail(int id=0)
        {
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel =articlePageBll.CreateArticleDetailModel(id);
            return View(articlePageViewModel);
        }
    }
}