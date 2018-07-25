using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class ArticleCategoryBll
    {
        ArticleCategoryDao acDao;
       
        public ArticleCategoryBll()
        {
            acDao = new ArticleCategoryDao();
        }
        public IEnumerable<ArticleCategory> GetAllCategory(int state)
        {
            ArticleCategory ac = new ArticleCategory();
            ac.category_state = state;
            return acDao.Select(ac);
        }

        public ArticleCategory GetCategory(ArticleCategory ac)
        {
            return acDao.Select(ac).FirstOrDefault();

        }
        public ArticleCategory GetCategory(int  category_id)
        {
            ArticleCategory ac = new ArticleCategory();
            ac.category_id = category_id;
            return acDao.Select(ac).FirstOrDefault();
        }
        public int GetCategoryIdByCode(string category_code)
        {
            ArticleCategory ac = new ArticleCategory();
            ac.category_code = category_code;
            ArticleCategory acNew = acDao.Select(ac).FirstOrDefault();
            return acNew.category_id;
        }
    }
}
