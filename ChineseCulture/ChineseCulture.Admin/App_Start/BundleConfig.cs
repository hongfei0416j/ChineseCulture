using System.Web;
using System.Web.Optimization;

namespace ChineseCulture.Admin
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                        "~/Content/assets/scss/_common.scss",
                      "~/Content/site.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/h-ui-js").Include(
                 "~/Content/lib/jquery/1.9.1/jquery.min.js",
                 "~/Content/lib/layer/2.4/layer.js",
                 "~/Content/h-ui/js/H-ui.js",
                 "~/Content/ib/My97DatePicker/4.8/WdatePicker.js",
                 "~/Content/lib/laypage/1.2/laypage.js",
                 "~/Content/lib/datatables/1.10.0/jquery.dataTables.min.js",
                 "~/Content/h-ui.admin/js/H-ui.admin.page.js"
                    ));
            bundles.Add(new StyleBundle("~/Content/h-ui-css").Include(
                      "~/Content/h-ui/css/H-ui.min.css",
                       "~/Content/h-ui.admin/css/H-ui.admin.css",
                       "~/Content/h-ui.admin/css/style.css",
                        "~/Content/h-ui.admin/skin/default/skin.css",
                        "~/Content/h-ui.admin/css/H-ui.login.css",
                        "~/Content/lib/Hui-iconfont/1.0.8/iconfont.css"
                      ));

        }
    }
}

/*
 * 
 * 
 *  <script type="text/javascript" src="lib/My97DatePicker/4.8/WdatePicker.js"></script>
    <script type="text/javascript" src="lib/datatables/1.10.0/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="lib/laypage/1.2/laypage.js"></script>


<script type="text/javascript" src="lib/jquery/1.9.1/jquery.min.js"></script>
<script type="text/javascript" src="lib/layer/2.4/layer.js"></script>

<script type="text/javascript" src="lib/jquery.validation/1.14.0/jquery.validate.js"></script>
<script type="text/javascript" src="lib/jquery.validation/1.14.0/validate-methods.js"></script>
<script type="text/javascript" src="lib/jquery.validation/1.14.0/messages_zh.js"></script>
<script type="text/javascript" src="static/h-ui/js/H-ui.js"></script>
<script type="text/javascript" src="static/h-ui.admin/js/H-ui.admin.page.js"></script>

     */
