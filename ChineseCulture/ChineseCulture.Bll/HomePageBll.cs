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
            homePageModel.Quanrizhi = articleBll.GetArticleByCategory("quanrizhi", 3);//文学作品
            homePageModel.zixuekaoshi = articleBll.GetArticleByCategory("zixuekaoshi", 3);//文学作品
            homePageModel.chengrenjiaoyu = articleBll.GetArticleByCategory("chengrenjiaoyu", 3);//文学作品

            homePageModel.youeryuan = articleBll.GetArticleByCategory("youeryuan", 9);//文学作品
            homePageModel.zaojiao = articleBll.GetArticleByCategory("zaojiao", 9);//文学作品
            homePageModel.xueqianban = articleBll.GetArticleByCategory("xueqianban", 9);//文学作品
            homePageModel.xiaoxue = articleBll.GetArticleByCategory("xiaoxue", 9);//文学作品
            homePageModel.chuzhong = articleBll.GetArticleByCategory("chuzhong", 9);//文学作品
            homePageModel.gaozhong = articleBll.GetArticleByCategory("gaozhong", 9);//文学作品
            homePageModel.daxue = articleBll.GetArticleByCategory("daxue", 9);//文学作品
            homePageModel.zhiyeyuanxiao = articleBll.GetArticleByCategory("zhiyeyuanxiao", 9);//文学作品
            homePageModel.teshujiaoyu = articleBll.GetArticleByCategory("teshujiaoyu", 9);//文学作品

            return homePageModel;
        }
    }
}
