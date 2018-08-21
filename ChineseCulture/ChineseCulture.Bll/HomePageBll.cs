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
        ArticleCategoryBll articleCategoryBll;
        ArticleCategoryDao acDao = new ArticleCategoryDao();
        public HomePageBll()
        {
            articleBll = new ArticleBll();
            articleCategoryBll = new ArticleCategoryBll();
            acDao = new ArticleCategoryDao();
        }

        public EventHomePageViewModel CreateEventPageModel()
        {
            EventHomePageViewModel eventHomePageViewModel = new EventHomePageViewModel();
            ArticleCategoryDao acDao = new ArticleCategoryDao();
            eventHomePageViewModel.SaiQuZuZhiDanWei = articleBll.GetArticleByCategory("saiquzuzhidanwei", 5);//赛区组织单位
            eventHomePageViewModel.SaiShiHuojiangBangdan = articleBll.GetArticleByCategory("saishihuojiangbangdan",5);//赛区组织单位

            /*文学教程*/
            eventHomePageViewModel.WenxueZuopinCategoryList = GetEventCategoryByCategoryCode("event_wenxuejiaocheng", 15);
            eventHomePageViewModel.WenxueZuopinCategoryArticleList = GetEventCategoryByFatherCategory("event_wenxuejiaocheng");


            /*书画手工*/
            eventHomePageViewModel.ShuhuashougongCategoryList = GetEventCategoryByCategoryCode("event_shuhuashougong", 15);
            eventHomePageViewModel.ShuhuashougongCategoryArticleList = GetEventCategoryByFatherCategory("event_shuhuashougong");

            /*艺术表演*/
            eventHomePageViewModel.YishubiaoyanCategoryList = GetEventCategoryByCategoryCode("event_yishubiaoyan", 15);
            eventHomePageViewModel.YishubiaoyanCategoryArticleList = GetEventCategoryByFatherCategory("event_yishubiaoyan");

            /*龙虎榜单*/
            eventHomePageViewModel.LonghubangdanCategoryList = GetEventCategoryByCategoryCode("event_longhubangdan", 15);
            eventHomePageViewModel.LonghubangdanCategoryArticleList = GetEventCategoryByFatherCategory("event_longhubangdan");
            /*学术交流*/
            eventHomePageViewModel.XueshujiaoliuCategoryList = GetEventCategoryByCategoryCode("event_xueshujiaoliu", 15);
            eventHomePageViewModel.XueshujiaoliuCategoryArticleList = GetEventCategoryByFatherCategory("event_xueshujiaoliu");
            /*历届赛事*/
            eventHomePageViewModel.LijiesaishiCategoryList = GetEventCategoryByCategoryCode("event_lijiesaishi", 15);
            eventHomePageViewModel.LijiesaishiCategoryArticleList = GetEventCategoryByFatherCategory("event_lijiesaishi");


            return eventHomePageViewModel;
        }

        private IEnumerable<ArticleCategory> GetEventCategoryByCategoryCode(string fathercategory_code, int category_number)
        {
            ArticleCategoryDao acDao = new ArticleCategoryDao();
            int father_id = articleCategoryBll.GetCategoryIdByCode(fathercategory_code);
            ArticleCategory ac = new ArticleCategory();
            ac.category_father_id = father_id;

            IEnumerable<ArticleCategory> arList = acDao.Select(ac).Take(category_number);//获取该类别下所有类别
            return arList;
        }

        public List<HomeCategoryArticleViewModel> GetEventCategoryByFatherCategory(string fathercategory_code)
        {
            ArticleCategoryDao acDao = new ArticleCategoryDao();
            int father_id = articleCategoryBll.GetCategoryIdByCode(fathercategory_code);
            ArticleCategory ac = new ArticleCategory();
            ac.category_father_id = father_id;
            ac.category_state = 0;
            ac.category_type = 2;//1的时候小导航 2的时候首页5个  3的时候广告
            IEnumerable<ArticleCategory> arList = acDao.Select(ac).Take(5);//获取该类别下所有子类别 小导航条
            List<HomeCategoryArticleViewModel> articleViewModelList = new List<HomeCategoryArticleViewModel>();
            //获取各类别下面的文章
            foreach (ArticleCategory item in arList)
            {
                HomeCategoryArticleViewModel articleViewModel = new HomeCategoryArticleViewModel();
                articleViewModel.category_name = item.category_name;
                articleViewModel.articleList = articleBll.GetArticleByCategory(item.category_code, 1).ToList();
                //articleViewModel.adArticle = articleBll.GetArticleByCategory(item.category_code, 1).FirstOrDefault();
                articleViewModelList.Add(articleViewModel);
            }
            return articleViewModelList;
        }


        public HomePageViewModel CreateHomePageModel()
        {
            HomePageViewModel homePageModel = new HomePageViewModel();
            homePageModel.ShouyeGundonggonggao = articleBll.GetArticleByCategory("shouyegundonggonggao", 1);
            homePageModel.Shouyegundonggonggaotupian = articleBll.GetArticleByCategory("shouyegundonggonggaotupian", 6);
            homePageModel.ShouyexuexiaoshipinOne = articleBll.GetArticleByCategory("Shouyexuexiaoshipin", 1).FirstOrDefault();
            homePageModel.ShouyexuexiaoshipinOnePic = articleBll.GetArticleByCategory("ShouyexuexiaoshipinOnePic", 1).FirstOrDefault();
            homePageModel.Shouyexuexiaotupian = articleBll.GetArticleByCategory("Shouyexuexiaotupian", 1);
            homePageModel.ShouyePeixunjigougundongtupian = articleBll.GetArticleByCategory("ShouyePeixunjigougundongtupian", 6);
            homePageModel.ShouyePeixunjigoutupian = articleBll.GetArticleByCategory("ShouyePeixunjigoutupian", 1);
            homePageModel.ShouyeQiuzhizhaopintupian = articleBll.GetArticleByCategory("ShouyeQiuzhizhaopintupian", 1);
            homePageModel.ShouyeZhuanjiajiangshigundongtupian = articleBll.GetArticleByCategory("ShouyeZhuanjiajiangshigundongtupian", 6);
            homePageModel.ShouyeZhuanjiajiangshitupian = articleBll.GetArticleByCategory("ShouyeZhuanjiajiangshitupian", 1);
            homePageModel.ShouyeXiaoyuanmingrentupian = articleBll.GetArticleByCategory("ShouyeXiaoyuanmingrentupian", 1);
            homePageModel.Shouyechuangyehezuogundongtupian = articleBll.GetArticleByCategory("Shouyechuangyehezuogundongtupian", 6);
            homePageModel.Shouyechuangyehezuotupian = articleBll.GetArticleByCategory("Shouyechuangyehezuotupian", 1);
            homePageModel.WangzhanGonggao = articleBll.GetArticleByCategory("wangzhangonggao", 7);//获取网站公告
            homePageModel.Zuixinzixun = articleBll.GetArticleByCategory("zuixinzixun", 3);//获取最新资讯
            homePageModel.Wenxuezuopin = articleBll.GetArticleByCategory("wenxuezuopin", 4);//文学作品

            homePageModel.XuexiaoFirst = GetAllCategoryByFatherCategory("xuexiao", 3,2);//首页学校
            homePageModel.XuexiaoDetail = GetAllCategoryByFatherCategory("xuexiao", 9, 1);//学校导航

            homePageModel.PeixunjigouFirst = GetAllCategoryByFatherCategory("peixunjigou", 3, 2);//培训机构
            homePageModel.PeixunjigouDetail = GetAllCategoryByFatherCategory("peixunjigou", 9, 1);//培训机构导航

            homePageModel.QiuzhizhaopinFirst = GetAllCategoryByFatherCategory("qiuzhizhaopin", 3, 2);//首页学校
            homePageModel.QiuzhizhaopinDetail = GetAllCategoryByFatherCategory("qiuzhizhaopin", 9, 1);//学校导航

            homePageModel.ZhuanjiajiangshiFirst = GetAllCategoryByFatherCategory("zhuanjiajiangshi", 3, 2);//首页学校
            homePageModel.ZhuanjiajiangshiDetail = GetAllCategoryByFatherCategory("zhuanjiajiangshi", 9, 1);//学校导航

            homePageModel.XiaoyuanmingrenFirst = GetAllCategoryByFatherCategory("xiaoyuanmingren", 3, 2);//首页学校
            homePageModel.XiaoyuanmingrenDetail = GetAllCategoryByFatherCategory("xiaoyuanmingren", 9, 1);//学校导航

            homePageModel.ChuangyehezuoFirst = GetAllCategoryByFatherCategory("chuangyehezuo", 3, 2);//首页学校
            homePageModel.ChuangyehezuoDetail = GetAllCategoryByFatherCategory("chuangyehezuo", 9, 1);//

            homePageModel.Bianminfuwu = articleBll.GetArticleByCategory("bianminfuwu", 5).ToList();//便民服务
            homePageModel.Caifuzhixing = articleBll.GetArticleByCategory("caifuzhixing", 5).ToList();
                homePageModel.Yulekuaibao= articleBll.GetArticleByCategory("yulekuaibao", 5).ToList();//娱乐快报
            homePageModel.Shijiaguanliyuan = articleBll.GetArticleByCategory("shijiaguanliyuan", 5).ToList();//十佳管理员
            return homePageModel;
        }
        public List<HomeCategoryArticleViewModel> GetAllCategoryByFatherCategory(string  fathercategory_code, int number, int category_type=1)
        {
            
            int father_id = articleCategoryBll.GetCategoryIdByCode(fathercategory_code);
            ArticleCategory ac = new ArticleCategory();
            ac.category_father_id = father_id;
            ac.category_state = 0;
            ac.category_type = category_type;//1的时候小导航 2的时候首页三个  3的时候广告
            IEnumerable<ArticleCategory> arList = acDao.Select(ac);//获取该类别下所有子类别 小导航条
            List<HomeCategoryArticleViewModel> articleViewModelList = new List<HomeCategoryArticleViewModel>();
            //获取各类别下面的文章
            foreach (ArticleCategory item in arList)
            {
                HomeCategoryArticleViewModel articleViewModel = new HomeCategoryArticleViewModel();
                articleViewModel.category_name = item.category_name;
                articleViewModel.articleList = articleBll.GetArticleByCategory(item.category_code, number).ToList();
                //articleViewModel.adArticle = articleBll.GetArticleByCategory(item.category_code, 1).FirstOrDefault();
                articleViewModelList.Add(articleViewModel);
            }
            return articleViewModelList;
        }
        
    }
}
