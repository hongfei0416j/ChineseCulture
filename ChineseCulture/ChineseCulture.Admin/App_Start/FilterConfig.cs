using ChineseCulture.Admin.App_Start;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionLogAttribute());
            filters.Add(new HandleLoginAttribute() { isCheck = true });
        }
    }
}
