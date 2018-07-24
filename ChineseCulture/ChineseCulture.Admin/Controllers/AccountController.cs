using ChineseCulture.Admin.App_Start;
using ChineseCulture.Bll;
using ChineseCulture.Common;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Account.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin
      
        [HandleLoginAttribute(isCheck =false)]
        public ActionResult Login()
        {
            return View();
        }
        [HandleLoginAttribute(isCheck = false)]
        public ActionResult LoginAction()
        {
            Member user = new Member();
            if (!string.IsNullOrEmpty(Request.Params["username"]))
            {
                user.member_name = Request.Params["username"].RepStr();

            }
            if (!string.IsNullOrEmpty(Request.Params["password"]))
            {
                user.member_password = Request.Params["password"].RepStr();

            }


            MemberBll adminBll = new MemberBll();
            try
            {
                if (adminBll.Login(user))
                {

                    HttpCookie cookie = new HttpCookie("session");

                    ///開發的時候不記錄domain二級域名

                    cookie.Expires = DateTime.Now.AddDays(1);
                    cookie["session_id"] = Session.SessionID;
                    cookie["callid"] = user.member_name;
                    Response.Cookies.Add(cookie);

                    Session["logingmessage"] = "";
                    Session["callid"] = user.member_name;

                    var all = new MemberLoginLog();
                    all.ip = CommonFunction.GetIP4Address(Request.UserHostAddress.ToString());
                    all.browser = Request.Browser.Browser;

                    return RedirectToAction("Index",
                           "Home");
                }
                else
                {
                    Session["logingmessage"] = "账号或者密码错误，请重新登陆!!!";
                    return RedirectToAction("login", "Account");
                    //Response.End();
                }
            }
            catch (Exception ex)
            {
                Session["logingmessage"] = "账号或者密码错误!!!";
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult AdminMenu()
        {
            List<AdminMenuViewModel> smvmList = new List<AdminMenuViewModel>();
            
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