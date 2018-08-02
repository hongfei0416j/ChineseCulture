using ChineseCulture.Bll;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Admin.Controllers
{
    public class FunctionController : Controller
    {
        // GET: Function
        public ActionResult Index()
        {
            FunctionBll funBll = new FunctionBll();
            var funList = funBll.GetAllAdminFunction();
            return View(funList);
        }
        public ActionResult Add()
        {
            ViewBag.FunctionFather = CreateFunctionFather().AsEnumerable(); ;
            return View();
        }

        private SelectList CreateFunctionFather(int selectValue = 0)
        {
            var funBll = new FunctionBll();
            //List<SelectListItem> ddlDPList = new List<SelectListItem>();

            SelectList ddlDPList;
            var dpList = funBll.GetAllAdminFatherFunction();
            if (selectValue == 0)
            {
                ddlDPList = new SelectList(dpList, "function_id", "function_name");
            }
            else
            {
                ddlDPList = new SelectList(dpList, "function_id", "function_name", selectValue);
            }



            return ddlDPList;
        }

        [HttpPost]
        public ActionResult Add(Function f)
        {
            f.function_sort = 0;
            f.kuser = Session["callid"].ToString();
            f.kdate = DateTime.Now;
            ViewBag.FunctionFather = CreateFunctionFather().AsEnumerable();
            FunctionBll functionBll = new FunctionBll();
            functionBll.AddFunction(f);

            return Redirect("index");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.FunctionFather = CreateFunctionFather().AsEnumerable(); ;
            FunctionBll funBll = new FunctionBll();
            Function fun = funBll.GetFunction(id);
            fun.function_id = id;
            return View(fun);
            
        }
        [HttpPost]
        public ActionResult Edit(Function fun )
        {
            FunctionBll funBll = new FunctionBll();
            funBll.UpdateFunction(fun);
            return Redirect("Index");
        }
    }
}