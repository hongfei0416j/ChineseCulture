using ChineseCulture.Bll;
using ChineseCulture.Common;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomePageBll homePageBll = new HomePageBll();
            var homePageModel = homePageBll.CreateHomePageModel();
            return View(homePageModel);
        }
        public ActionResult Reg()
        {
            string telphone = "";
            return View();
        }
        public ActionResult RegCheck()
        {
            var userBll = new UserBll();
            var uModel = new User();
            uModel.user_telephone = Request.Params["mobile"].ToString();
            uModel.user_password = Request.Params["password"].ToString();
            uModel.user_name = Request.Params["username"].ToString();
            uModel.user_regdate = DateTime.Now;
            uModel.user_state = 1;
            userBll.RegUser(uModel);
            return Redirect("/home/index");
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginCheck()
        {
            
            var userBll = new UserBll();
            if (!string.IsNullOrEmpty(Request.Params["username"]))
            {
                string username = Request.Params["username"].ToString();
                string password = Request.Params["password"].ToString();
               var user  = userBll.CheckUserPassword(username,password);
                if (user!=null)
                {
                    Session["username"] = user.user_name;
                    return Redirect("index");
                }
                else
                {
                    return Redirect("login");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.Params["mobile"]))
                {
                    string mobile = Request.Params["mobile"].ToString();
                    string generate_code = Request.Params["generate_code"].ToString();
                    var user = userBll.CheckUserGenerateCode(Session["generate_code"].ToString(), generate_code,mobile);
                    if (user != null)
                    {
                        Session["username"] = user.user_name;
                        return Redirect("index");
                    }
                    else
                    {
                        return Redirect("login");
                    }
                }
               
            }
            return View("login");
            // return View();
        }
        public string getCode()
        {
            string code = DateTime.Now.ToString("sfff");
            code = "1234";
            Session["generate_code"] = code;
            var smsHelper = new SMSHelper();
            //smsHelper.SendSms("15638814321","code");

            return code;
        }
    }
}