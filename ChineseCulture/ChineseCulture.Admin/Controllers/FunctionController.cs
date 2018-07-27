﻿using ChineseCulture.Bll;
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
            return View();
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
        public ActionResult Edit()
        {
            return View();
        }
    }
}