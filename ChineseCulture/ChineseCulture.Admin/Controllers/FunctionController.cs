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
            return View();
        }
        [HttpPost]
        public ActionResult Add(Function f)
        {
            FunctionBll functionBll = new FunctionBll();
            functionBll.AddFunction(f);
            return View();
        }
        public ActionResult Edit(int id)
        {
            FunctionBll funBll = new FunctionBll();
            var fun = funBll.GetFunction(id);
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