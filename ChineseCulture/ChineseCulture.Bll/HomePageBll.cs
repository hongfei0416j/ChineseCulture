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
        ArticleDao articleDao;
        public HomePageBll()
        {
            articleDao = new ArticleDao();
        }
        public HomePageViewModel CreateHomePageModel()
        {
            HomePageViewModel homePageModel = new HomePageViewModel();
            homePageModel.WangzhanGonggao = articleDao.Select(new Article { article_state=1,category_id=2});//获取网站公告

            return homePageModel;
        }
    }
}
