using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class ArticleBll
    {
        ArticleDao articleDao;
        public ArticleBll()
        {
            articleDao = new ArticleDao();

        }
        public void AddArticle(Article article)
        {

            article.article_kdate = DateTime.Now;
            article.article_mdate = DateTime.Now;
            articleDao.Add(article);

        }
        public List<Article> GetAllArticle()
        {
            Article a = new Article();
           return  articleDao.Select(a).ToList();
        }

        public Article GetArticle(Article article)
        {
            Article a = new Article();
            return articleDao.Select(a).FirstOrDefault();
        }
    }
}
