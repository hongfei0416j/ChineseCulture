using ChineseCulture.Bll;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            User user = new User();
            int user_id =0;
            try
            {
                user_id =Convert.ToInt32( Session["user_id"].ToString());
                UserBll userBll = new UserBll();
                user =  userBll.GetUser(user_id);
            }
            catch (Exception)
            {
                return Redirect("/home/index");


            }
            return View(user);
        }
        public ActionResult UserEdit()
        {
            return View();
        }
        public ActionResult SendArticle()
        {
            ViewBag.ArticleCategory = GetAllCategoryForDLL().AsEnumerable();
            return View();
        }
        private SelectList GetAllCategoryForDLL(int selectValue = 0)
        {
            var acBll = new ArticleCategoryBll();
            //List<SelectListItem> ddlDPList = new List<SelectListItem>();

            SelectList ddlDPList;
            var dpList = acBll.GetAllCategory(1);

            if (selectValue == 0)
            {
                ddlDPList = new SelectList(dpList, "category_id", "category_name");
            }
            else
            {
                ddlDPList = new SelectList(dpList, "category_id", "category_name", selectValue);
            }


            return ddlDPList;

        }
    }
}