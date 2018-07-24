using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChineseCulture.Admin.App_Start
{
    public class HandleLoginAttribute: ActionFilterAttribute
    {
        public bool isCheck { set; get; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (isCheck)
            {
                HttpCookie cookie = filterContext.HttpContext.Request.Cookies["session"];
                //string cookieValue = cookie.Value;
                if (cookie == null)
                {
                    //跳转到登陆页
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login", area = string.Empty }));
                }

                else
                {
                    
                    
                    //s.caller_id = sessionMgr.GetMessageBySession(cookie.Values["session_id"]);
                    string callid = cookie.Values["callid"];
                    filterContext.HttpContext.Session["callid"] = callid;

                    //filterContext.HttpContext.Response.Write(filterContext.HttpContext.Session["callid"]);
                    //跳转到首页

                    //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", area = string.Empty }));

                       
                    
                }
              
            }
        }
    }
}