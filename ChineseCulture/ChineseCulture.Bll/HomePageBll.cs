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
        public HomePageBll()
        {
            articleBll = new ArticleBll();
            articleCategoryBll = new ArticleCategoryBll();
        }
        public HomePageViewModel CreateHomePageModel()
        {
            HomePageViewModel homePageModel = new HomePageViewModel();

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
            ArticleCategoryDao acDao = new ArticleCategoryDao();
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
