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
        public ActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(ArticleCategory ac)
        {
            ArticleCategoryBll acBll = new ArticleCategoryBll();
            acBll.AddArticleCategory(ac);
            return View();
        }
        public ActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return View("Index");
            }
            ArticleCategoryBll categoryBll = new ArticleCategoryBll();
            ArticleCategory category = new ArticleCategory();
            category.category_id = id;
            category = categoryBll.GetCategory(category);
            category.category_id = id;
            ViewBag.ArticleCategory = GetAllCategoryFatherForDLL(category.category_id).AsEnumerable();
            return View(category);
        }

        private SelectList GetAllCategoryFatherForDLL(int selectValue=0)
        {
            var acBll = new ArticleCategoryBll();
            //List<SelectListItem> ddlDPList = new List<SelectListItem>();

            SelectList ddlDPList;
            var dpList = acBll.GetAllCategoryFather();
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

        [HttpPost]
        public ActionResult Edit(ArticleCategory ac)
        {
            var acBll = new ArticleCategoryBll();
            acBll.UpdateArticleCategory(ac);
            return Redirect("index");
        }
    }
}