using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using ChineseCulture.Bll;
using ChineseCulture.Model;

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
        public ActionResult List(int pageindex = 1, int cid = 0)
        {
            if (cid > 1)
            {
                Session["category_id"] = cid;

            }
            if (pageindex == null || pageindex < 0)
            {
                pageindex = 0;
            }
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel.page_index = pageindex;
            articlePageViewModel.ThisArticleCategory = new ArticleCategory();
            articlePageViewModel.ThisArticleCategory.category_id = Convert.ToInt32(Session["category_id"]);
            articlePageViewModel.category_id = Convert.ToInt32(Session["category_id"]);
            articlePageViewModel = articlePageBll.CreateEventListModel(articlePageViewModel);
            return View(articlePageViewModel);
        }
        public ActionResult Detail(int id = 0)
        {
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel = articlePageBll.CreateArticleDetailModel(id,1);
            return View(articlePageViewModel);
        }
        [HttpPost]
        public HttpContextBase AddTick(int id)
        {
            ArticleBll acBll = new ArticleBll();

            ArticleTicks at = new ArticleTicks();
            at.article_id = id;
            at.at_brower = Request.Browser.Browser;
            at.at_device = Request.UserHostName;
            at.at_ipfrom = Request.UserHostAddress;
            at.at_kdate = DateTime.Now;
            at.at_kuser = "";
            //acBll.AddTick();
            acBll.AddTick(at);
            return null;
        }
        public ActionResult Baoming()
        {
            
            return View();
        }
        [HttpPost]
        public HttpContextBase Baoming(string  b)
        {
            return null;
        }
    }
}