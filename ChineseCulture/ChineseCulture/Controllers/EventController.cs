using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using ChineseCulture.Bll;
using ChineseCulture.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChineseCulture.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            HomePageBll homePageBll = new HomePageBll();
            var homePageModel = homePageBll.CreateEventPageModel();
            return View(homePageModel);
            
        }
        public ActionResult List(int pageindex = 1, int cid = 0)
        {
            if (cid > 1)
            {
                Session["category_id"] = cid;

            }
            if (pageindex == null || pageindex < 0)
            {
                pageindex = 0;
            }
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel.page_index = pageindex;
            articlePageViewModel.ThisArticleCategory = new ArticleCategory();
            articlePageViewModel.ThisArticleCategory.category_id = Convert.ToInt32(Session["category_id"]);
            articlePageViewModel.category_id = Convert.ToInt32(Session["category_id"]);
            articlePageViewModel = articlePageBll.CreateEventListModel(articlePageViewModel);
            return View(articlePageViewModel);
        }
        public ActionResult Detail(int id = 0)
        {
            ArticlePageViewModel articlePageViewModel = new ArticlePageViewModel();
            ArticlePageBll articlePageBll = new ArticlePageBll();
            articlePageViewModel = articlePageBll.CreateArticleDetailModel(id,1);
            return View(articlePageViewModel);
        }

        public HttpContextBase AddTick(int id)
        {
            ArticleBll acBll = new ArticleBll();

            ArticleTicks at = new ArticleTicks();
            at.article_id = id;
            at.at_brower = Request.Browser.Browser;
            at.at_device = Request.UserHostName;
            at.at_ipfrom = Request.UserHostAddress;
            at.at_kdate = DateTime.Now;
            at.at_kuser = "";
            //acBll.AddTick();
            acBll.AddTick(at);
            return null;
        }
        public ActionResult Baoming()
        {
            try
            {//产品名称:云通信短信API产品,开发者无需替换
                const String product = "Dysmsapi";
                //产品域名,开发者无需替换
                const String domain = "dysmsapi.aliyuncs.com";

                // TODO 此处需要替换成开发者自己的AK(在阿里云访问控制台寻找)
                const String accessKeyId = "LTAISo5urmb4p9OA";
                const String accessKeySecret = "6dQblI0XUTXIOheTZnvAive2g2hEss";
                IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
                DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
                IAcsClient acsClient = new DefaultAcsClient(profile);
                SendSmsRequest request = new SendSmsRequest();
                SendSmsResponse response = null;
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = "15638814321";
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "校园之星原创文艺作品争霸";
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = "SMS_148350075";
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = "{\"code\":\"123\"}";
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                response = acsClient.GetAcsResponse(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }
        [HttpPost]
        public HttpContextBase Baoming(string  b)
        {
            return null;
        }
    }
}