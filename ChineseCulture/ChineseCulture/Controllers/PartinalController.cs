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
            IEnumerable<SiteMenu> siteMenuList = smBll.GetPageMenuByCategory("shouyetop");
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
        public ActionResult FooterGuanyuwomen()
        {
            ArticleBll acBll = new ArticleBll();

            var articleList = acBll.GetArticleByCategory("footerguanyuwomen", 7);
            return View(articleList);

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
        public ActionResult WenyizashiHomeMenu()
        {
            SiteMenuBll smBll = new SiteMenuBll();
            IEnumerable<SiteMenu> siteMenuList = smBll.GetPageMenuByCategory("wenyizazhidaohang");
            return View(siteMenuList);
        }
        public ActionResult PageHeader() 
        {
            UserViewModel user = new UserViewModel();

            if (null!= Session["username"]&&!string.IsNullOrEmpty(Session["username"].ToString()))
            {
                user.isLogin = true;
                user.isLoginButtonShow = "hidden";
                user.isUserShow = "";
                user.username = Session["username"].ToString();
            }
            else
            {
                user.isLogin = false;
                user.isLoginButtonShow = "";
                user.isUserShow = "hidden";
            }
            return View(user);
        }
        public ActionResult EventPageHeader()
        {
            return View();
        }
        public ActionResult WenyizazhiPageHeader()
        {
            return View();
        }
    }
}