using ChineseCulture.Common;
using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace ChineseCulture.Bll
{
    public class ArticleBll
    {
        ArticleDao articleDao;
        ArticleCategoryBll acdBll;
        public ArticleBll()
        {
            articleDao = new ArticleDao();
            acdBll = new ArticleCategoryBll();

        }
        public void AddArticle(Article article)
        {

            article.article_kdate = DateTime.Now;
            article.article_mdate = DateTime.Now;
            articleDao.Add(article);

        }
        public List<Article> GetAllArticle(Article a)
        {
           var articleList=  articleDao.Select(a).ToList();
           
          
            articleList.ForEach(t=>t.category_name= acdBll.GetCategory(t.category_id).category_name);
            return articleList;
        }


        public Article GetArticle(Article article)
        {
           
            return articleDao.Select(article).FirstOrDefault();
        }

        internal ArticleCategory GetArticleCategoryByArticle(int article_id)
        {
            Article a = new Article();
            a.article_id = article_id;
            a = articleDao.Select(a).FirstOrDefault();
            ArticleCategory ac =  acdBll.GetCategory(new ArticleCategory { category_id=a.category_id});
            return ac;

        }
        internal ArticleCategory GetArticleFatherCategoryByArticle(int article_id)
        {
            Article a = new Article();
            a.article_id = article_id;
            a = articleDao.Select(a).FirstOrDefault();
            ArticleCategory ac = acdBll.GetCategory(new ArticleCategory { category_id = a.category_id });
            ArticleCategory acFather = acdBll.GetCategory(new ArticleCategory { category_id = ac.category_father_id });
            return acFather;
        }

        internal PagedList<Article> GetEventPageList(ArticlePageViewModel articleDetailModel)
        {
            var articleList = articleDao.SelectPageList(articleDetailModel);//获取网站公告
            articleList.ForEach(t => t.article_click_url = "/Event/Detail/" + t.article_id);
            articleList.ForEach(t => t.article_description = string.IsNullOrEmpty(t.article_description) ? StringHelper.ReplaceHtmlTag(t.article_content, 200) : t.article_description);
            return articleList;
        }

        public void AddTick(ArticleTicks at)
        {
            articleDao.AddArticleTick(at);
            articleDao.UpdateTickOfArticle(at);
        }

        public void EditArticle(Article article)
        {
           
            article.article_mdate = DateTime.Now;
            articleDao.Update(article);
        }
        public IEnumerable<Article> GetArticleByCategory(string category_code,int number)
        {
            ArticleCategoryBll articleCategoryBll = new ArticleCategoryBll();
            Article article = new Article();
            article.category_id = articleCategoryBll.GetCategoryIdByCode(category_code);
            article.article_state = 1;
            
            var articleList =articleDao.Select(article , number).ToList();//获取网站公告
            articleList.ForEach(t => t.category_name = acdBll.GetCategory(t.category_id).category_name);

            articleList.ForEach(t=>t.article_click_url="/Article/Detail/"+t.article_id);
            return articleList;
        }

        internal PagedList<Article> GetArticlePageList(ArticlePageViewModel articleDetailModel)
        {
            var articleList =  articleDao.SelectPageList(articleDetailModel);//获取网站公告
            articleList.ForEach(t => t.article_click_url = "/Article/Detail/" + t.article_id);
            articleList.ForEach(t => t.article_description =string.IsNullOrEmpty(t.article_description)?StringHelper.ReplaceHtmlTag(t.article_content,200):t.article_description);
            return articleList;
        }

        public IEnumerable<Article> GetArticleByFatherCategory(string father_category_code, int number)
        {
            ArticleCategoryBll articleCategoryBll = new ArticleCategoryBll();
            Article article = new Article();
            article.category_id = articleCategoryBll.GetCategoryIdByCode(father_category_code);
            article.article_state = 1;
            var articleList = articleDao.Select(article, number).ToList();//获取网站公告
            articleList.ForEach(t => t.category_name = acdBll.GetCategory(t.category_id).category_name);
            articleList.ForEach(t => t.article_click_url = "/Article/Detail/" + t.article_id);
            return articleList;
        }
       
    }
}
