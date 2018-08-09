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
            ac.category_father_id = 0;
            return acDao.Select(ac);
        }
        public IEnumerable<ArticleCategory> GetCategoryList(ArticleCategory ac)
        {
            
            ac.category_state = 1;

            return acDao.Select(ac);
        }
        public ArticleCategory GetCategory(ArticleCategory ac)
        {
            return acDao.Select(ac).FirstOrDefault();

        }

        public void AddArticleCategory(ArticleCategory ac)
        {
            acDao.Add(ac);
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
            ac.category_father_id = 0;
            ArticleCategory acNew = acDao.Select(ac).FirstOrDefault();
            return acNew.category_id;
        }
        public void UpdateArticleCategory(ArticleCategory ac)
        {
            acDao.Update(ac);

        }

        public IEnumerable<ArticleCategory> GetAllCategoryFather()
        {
            ArticleCategory ac = new ArticleCategory();
            ac.category_father_id = 1;
            ac.category_state = 1;
            return acDao.Select(ac);
        }
        
    }
}
