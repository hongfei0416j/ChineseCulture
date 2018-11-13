using ChineseCulture.Bll;
using ChineseCulture.Common;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        
        public ActionResult SendArticle()
        {
            ViewBag.ArticleCategory = GetAllCategoryForDLL().AsEnumerable();
            return View();
        }
        public ActionResult UserEdit(int id)
        {

            if (id == null || id == 0)
            {
                return View("Index");
            }
            ArticleBll articleBll = new ArticleBll();
            Article article = new Article();
            article.article_id = id;
            article = articleBll.GetArticle(article);
            article.article_id = id;
            ViewBag.ArticleCategory = GetAllCategoryForDLL(article.category_id).AsEnumerable();
            return View(article);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UserEdit(Article ar)
        {
            ar = (Article)ModelHelper.ModelSupplement(ar);
            //string  id = Request.Params["article_id"];
            foreach (string upload in Request.Files.AllKeys)
            {

                HttpPostedFileBase excelFile = Request.Files["article_cover_image"];
                if (excelFile.ContentLength > 0)
                {
                    DateTime now = DateTime.Now;
                    string newDirPath = string.Format(@"{0}\{1}\{2}\", Server.MapPath("../"), "Upload", now.ToString(@"yyyy\\mm\\dd"));
                    string newUrlPath = string.Format("/{0}/{1}/", "Upload", now.ToString("yyyy/mm/dd"));
                    string newPath = Path.Combine(Server.MapPath(@"..\"), "Upload", "");
                    string fileName = now.ToFileTime().ToString() + excelFile.FileName.Substring(excelFile.FileName.LastIndexOf('.'));
                    ar.article_cover_image = newUrlPath + fileName;
                    if (!Directory.Exists(newDirPath))
                    {
                        Directory.CreateDirectory(newDirPath);
                    }
                    excelFile.SaveAs(newDirPath + fileName);
                }
            }

            ar.article_muser = Session["user_id"].ToString();
            if (ModelState.IsValid)
            {
                ArticleBll articleBll = new ArticleBll();
                articleBll.EditArticle(ar);
            }

            //RedirectToAction("index");
            return Redirect("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddArticle(Article ar)
        {
            ar = (Article)ModelHelper.ModelSupplement(ar);
            ViewBag.ArticleCategory = GetAllCategoryForDLL(ar.category_id).AsEnumerable();
            foreach (string upload in Request.Files.AllKeys)
            {

                HttpPostedFileBase excelFile = Request.Files["article_cover_image"];

                if (excelFile.ContentLength > 0)
                {
                    DateTime now = DateTime.Now;
                    string newDirPath = string.Format(@"{0}\{1}\{2}\", Server.MapPath("../"), "Upload", now.ToString(@"yyyy\\mm\\dd"));
                    string newUrlPath = string.Format("/{0}/{1}/", "Upload", now.ToString("yyyy/mm/dd"));
                    string newPath = Path.Combine(Server.MapPath(@"..\"), "Upload", "");
                    string fileName = now.ToFileTime().ToString() + excelFile.FileName.Substring(excelFile.FileName.LastIndexOf('.'));
                    ar.article_cover_image = newUrlPath + fileName;
                    if (!Directory.Exists(newDirPath))
                    {
                        Directory.CreateDirectory(newDirPath);
                    }
                    excelFile.SaveAs(newDirPath + fileName);
                }

            }
            ar.article_kuser = Session["user_id"].ToString();
            ar.article_muser = Session["user_id"].ToString();
            if (ModelState.IsValid)
            {
                ArticleBll articleBll = new ArticleBll();
                articleBll.AddArticle(ar);
            }

            return Redirect("index");
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