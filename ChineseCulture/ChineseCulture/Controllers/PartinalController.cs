using ChineseCulture.Bll;
using ChineseCulture.Model;
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
            SiteMenuBll smBll = new SiteMenuBll();
            IEnumerable<SiteMenu> siteMenuList =  smBll.GetPageMenuByCategory("shouyetop");
            return View(siteMenuList);
        }
        public ActionResult HomePageCategoryMenu()
        {
            SiteMenuBll smBll = new SiteMenuBll();
            List<SiteMenuViewModel> siteMenuModelList = new List<SiteMenuViewModel>();
            IEnumerable<SiteMenu> siteMenuList = smBll.GetPageMenuByCategory("3");
            foreach (var item in siteMenuList)
            {
                SiteMenuViewModel smvm = new SiteMenuViewModel();
                smvm.menu_name = item.menu_name;
                smvm.siteMenuList = smBll.GetPageMenuByCategory(item.menu_code);
                siteMenuModelList.Add(smvm);
            }
            return View(siteMenuModelList);
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult FriendLink()
        {
            ArticleBll acBll = new ArticleBll();

            var articleList = acBll.GetArticleByCategory("FriendLink", 100);
            return View(articleList);
        }
        public ActionResult EventHomeMenu()
        {
            SiteMenuBll smBll = new SiteMenuBll();
            IEnumerable<SiteMenu> siteMenuList = smBll.GetPageMenuByCategory("saishidaohang");
            return View(siteMenuList);
        }
        public ActionResult PageHeader()
        {
            return View();
        }
    }
}