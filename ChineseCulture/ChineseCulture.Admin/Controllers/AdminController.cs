using ChineseCulture.Bll;
using ChineseCulture.Common;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginAction()
        {
            admin user = new admin();
            if (!string.IsNullOrEmpty(Request.Params["username"]))
            {
                user.admin_name = Request.Params["username"].RepStr();

            }
            if (!string.IsNullOrEmpty(Request.Params["password"]))
            {
                user.admin_password = Request.Params["password"].RepStr();

            }


            AdminBll adminBll = new AdminBll();
            try
            {
                if (adminBll.Login(user))
                {

                    HttpCookie cookie = new HttpCookie("session");

                    ///開發的時候不記錄domain二級域名

                    cookie.Expires = DateTime.Now.AddDays(1);
                    cookie["session_id"] = Session.SessionID;
                    cookie["callid"] = user.admin_name;
                    Response.Cookies.Add(cookie);

                    Session["logingmessage"] = "";
                    Session["callid"] = user.admin_name;

                    admin_login_log all = new admin_login_log();
                    all.ip = CommonFunction.GetIP4Address(Request.UserHostAddress.ToString());
                    all.browser = Request.Browser.Browser;

                    return RedirectToAction("Index",
                           "Admin");
                }
                else
                {
                    Session["logingmessage"] = "账号或者密码错误，请重新登陆!!!";
                    return RedirectToAction("login", "Admin");
                    //Response.End();
                }
            }
            catch (Exception ex)
            {
                Session["logingmessage"] = "账号或者密码错误!!!";
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult AdminMenu()
        {
            List<AdminMenuViewModel> smvmList = new List<AdminMenuViewModel>();
            
            AdminMenuViewModel amvm1 = new AdminMenuViewModel();
            amvm1.function = new function();
            amvm1.function.function_name = "菜单1";
            
            AdminMenuViewModel amvm2 = new AdminMenuViewModel();
            amvm2.function = new function();
            amvm2.function.function_name = "菜单2";
            AdminMenuViewModel amvm3 = new AdminMenuViewModel();
            amvm3.function = new function();
            amvm3.function.function_name = "菜单3";
            amvm1.chiledFunction = new List<function>();
            amvm1.chiledFunction.Add(new function { function_name = "Hello" });
            amvm1.chiledFunction.Add(new function { function_name = "Hello2" });
            amvm1.chiledFunction.Add(new function { function_name = "Hello3" });
            amvm1.chiledFunction.Add(new function { function_name = "Hello4" });

            smvmList.Add(amvm1);
            smvmList.Add(amvm2);
            smvmList.Add(amvm3);
            return PartialView(smvmList);
        }

        public ActionResult CheckCode()
        {
            //生成验证码
            ValidateCode validateCode = new ValidateCode();//这里是我在控制器来新建了一个叫ValidataCode的类，作用是相当的强大，下面我就贴这个类的代码
            string code = validateCode.CreateValidateCode(4);//这里是调用ValidataCode这个类的CrratVAalidataCode方法，这可方法主要就用来返回验证码的字符串，参数4是返回一个4位的字符串
            Session["ValidateCode"] = code;//把返回的字符串加入Sesstion里
            byte[] bytes = validateCode.CreateValidateGraphic(code);//这里也是调用了CreateValidataGraphic的这个方法，返回二进制位的字节，也就是图片的字节数据
            return File(bytes, @"image/jpeg");
        }
    }
}