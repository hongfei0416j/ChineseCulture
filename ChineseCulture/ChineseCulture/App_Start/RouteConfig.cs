using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChineseCulture
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "MvcPager_Pager1",
              url: "{controller}/page_{pageindex}.html",
              defaults: new { controller = "Article", action = "List", cid = UrlParameter.Optional, pageindex = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "MvcPager_Pager2",
               url: "{controller}/{action}/page_{pageindex}",
               defaults: new { controller = "Article", action = "List",cid  = UrlParameter.Optional, pageindex = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "MvcPager_Default",
              url: "{controller}/cid_{cid}.html",
              defaults: new { controller = "Article", action = "List", cid = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "MvcPager_DefaultEvent",
             url: "{controller}/ecid_{cid}.html",
             defaults: new { controller = "Event", action = "List", cid = UrlParameter.Optional }
         );
            routes.MapRoute(
               name: "MvcPager_Default2",
               url: "{controller}/{action}/cid_{cid}",
               defaults: new { controller = "Article", action = "List", cid = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default2",
                url: "{controller}/article_{id}.html",
                defaults: new { controller = "Article", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Defaultevent",
               url: "{controller}/event_{id}.html",
               defaults: new { controller = "Event", action = "Detail", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           
           
           
        }
    }
}
