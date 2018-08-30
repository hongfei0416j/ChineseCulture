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
        public ActionResult List(int pageindex = 1,int cid = 0)
        {
            if (cid>1)
            {
                Session["category_id"] = cid;
                
            }
            if (pageindex == null|| pageindex < 0)
            {
                pageindex = 0;
            }
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel.page_index = pageindex;
            articlePageViewModel.ThisArticleCategory = new ArticleCategory();
            articlePageViewModel.ThisArticleCategory.category_id =Convert.ToInt32(Session["category_id"]);
            articlePageViewModel.category_id = Convert.ToInt32(Session["category_id"]);
            articlePageViewModel = articlePageBll.CreateArticleListModel(articlePageViewModel);
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