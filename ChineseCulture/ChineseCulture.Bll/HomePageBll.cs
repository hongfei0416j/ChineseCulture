using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class HomePageBll
    {
        ArticleBll articleBll;
        
        public HomePageBll()
        {
            articleBll = new ArticleBll();
        }
        public HomePageViewModel CreateHomePageModel()
        {
            HomePageViewModel homePageModel = new HomePageViewModel();

            homePageModel.WangzhanGonggao = articleBll.GetArticleByCategory("wangzhangonggao", 7);//获取网站公告
            homePageModel.Zuixinzixun = articleBll.GetArticleByCategory("zuixinzixun", 3) ;//获取最新资讯
            homePageModel.Wenxuezuopin = articleBll.GetArticleByCategory("wenxuezuopin", 4);//文学作品


            return homePageModel;
        }
    }
}
