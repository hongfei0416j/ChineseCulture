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
            HttpCookie cookie = new HttpCookie("UserInfoRemember");
            if (cookie!=null&&!string.IsNullOrEmpty(cookie["username"]) && !string.IsNullOrEmpty(cookie["user_id"]))
            {
                Session["username"] = cookie["username"].ToString();
                Session["password"] = cookie["password"].ToString();
                Session["mobile"] = cookie["mobile"].ToString();
                Session["user_id"] = cookie["user_id"].ToString();
                return Redirect("Index");
            }
            
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
                    UserLoginLog ull = new UserLoginLog() { user_id = user.user_id, browser = Request.Browser.Browser, kdate = DateTime.Now, ip = Request.UserHostAddress };
                    HttpCookie cookie = new HttpCookie("UserInfoRemember");
                    if (cookie != null)
                    {
                        Session["username"] = cookie["username"]= user.user_name;
                        Session["password"] = cookie["password"] = user.user_password;
                        Session["mobile"] = cookie["mobile"] = user.user_telephone;
                        Session["user_id"] = cookie["user_id"] = user.user_id.ToString(); ;
                        return Redirect("Index");
                    }
                    userBll.AddUserLoginLog(ull);
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
                        UserLoginLog ull = new UserLoginLog() { user_id = user.user_id, browser = Request.Browser.Browser ,kdate=DateTime.Now,ip= Request.UserHostAddress}; HttpCookie cookie = new HttpCookie("UserInfoRemember");
                        if (cookie != null)
                        {
                            Session["username"] = cookie["username"] = user.user_name;
                            Session["password"] = cookie["password"] = user.user_password;
                            Session["mobile"] = cookie["mobile"] = user.user_telephone;
                            Session["user_id"] = cookie["user_id"] = user.user_id.ToString(); ;
                            return Redirect("Index");
                        }
                        userBll.AddUserLoginLog(ull);
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
        [HttpPost]
        public bool getCode()
        {
            
            var smsHelper = new SMSHelper();
            string mobile, code = ""; 
            try
            {
                UserBll uBll = new UserBll();
                mobile =Request.Params["mobile"].ToString();
                if (uBll.CheckCanSendSms(mobile))
                {
                    code = DateTime.Now.ToString("ssff");
                    //code = "1234";
                    Session["generate_code"] = code;
                    smsHelper.SendSms(mobile, code);
                    SMSLog smsLog = new SMSLog() { telephone = mobile, content = code, Browser = Request.Browser.Browser, ip = Request.UserHostAddress, kdate = DateTime.Now };
                    uBll.AddUserSMSLog(smsLog);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool checkUserCode()
        {
            string userCode = Request.Params["code"];
            if (string.IsNullOrEmpty(userCode))
            {
                return false;
            }
            else
            {
                if (userCode== Session["generate_code"].ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ActionResult CityChange()
        {
            return View();
        }
    }
}