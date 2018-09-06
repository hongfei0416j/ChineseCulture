using ChineseCulture.Bll;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Admin.Controllers
{
    public class SiteMenuController : Controller
    {
        // GET: SiteMenu
        public ActionResult Index()
        {
            
               SiteMenuBll siteMenuBll = new SiteMenuBll();
            var menuList = siteMenuBll.SelectAllMenu();
            return View(menuList);
            
        }
        public ActionResult Add()
        {
            ViewBag.MenuFather = GetAllMenuFatherForDLL().AsEnumerable();
            return View();
        }

        private SelectList GetAllMenuFatherForDLL(int selectValue = 0)
        {
            var smBll = new SiteMenuBll();
            //List<SelectListItem> ddlDPList = new List<SelectListItem>();

            SelectList ddlDPList;
            var dpList = smBll.GetAllMenuFather();
            if (selectValue == 0)
            {
                ddlDPList = new SelectList(dpList, "menu_id", "menu_name");
            }
            else
            {
                ddlDPList = new SelectList(dpList, "menu_id", "menu_name", selectValue);
            }



            return ddlDPList;
        }

        [HttpPost]
        public ActionResult Add(SiteMenu sm)
        {
            ViewBag.MenuFather = GetAllMenuFatherForDLL(sm.menu_father_id).AsEnumerable();
            SiteMenuBll smBll = new SiteMenuBll();
            smBll.AddSiteMenu(sm);
            return Redirect("index");
        }
        public ActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return View("Index");
            }
            SiteMenuBll smBll = new SiteMenuBll();
            SiteMenu sm = new SiteMenu();
            sm.menu_id = id;
            sm = smBll.GetOneMenu(sm);
            sm.menu_id = id;
            ViewBag.MenuFather = GetAllMenuFatherForDLL(sm.menu_father_id).AsEnumerable();
            return View(sm);
        }
        [HttpPost]
        public ActionResult Edit(SiteMenu sm)
        {
            SiteMenuBll smBll = new SiteMenuBll();
            ViewBag.MenuFather = GetAllMenuFatherForDLL().AsEnumerable();
            SiteMenuBll funBll = new SiteMenuBll();
            smBll.UpdateSiteMenu(sm);
            return Redirect("Index");
           
        }
    }
}