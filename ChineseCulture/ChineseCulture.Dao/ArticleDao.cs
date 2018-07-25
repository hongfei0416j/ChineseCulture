using ChineseCulture.Dao.Interface;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao
{
    public class ArticleDao : IArticleDao
    {
        ChineseCultureDBEntities db;
        public ArticleDao()
        {
            db = new ChineseCultureDBEntities();
        }
        public bool Add(Article article)
        {
            db.Article.Add(article);
            return db.SaveChanges() > 0;
        }

        public bool Delete(Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> Select(Article article)
        {
            int article_id = article.article_id;
            int category_id = article.category_id;
            int article_state = article.article_state;

            var query = db.Article.Where(t =>
            (category_id == 0 || t.category_id == category_id) &&
            (article_state == 0||t.article_state==article_state)&&
            (article_id==0||t.article_id==article_id)).OrderBy(t=>t.article_sort).OrderByDescending(s=>s.article_kdate);
            return query.ToList();
        }
        public IEnumerable<Article> Select(Article article,int number)
        {
            int article_id = article.article_id;
            int category_id = article.category_id;
            int article_state = article.article_state;

            var query = db.Article.Where(t =>
            (category_id == 0 || t.category_id == category_id) &&
            (article_state == 0 || t.article_state == article_state) &&
            (article_id == 0 || t.article_id == article_id)).OrderBy(t => t.article_sort).OrderByDescending(s => s.article_kdate);
            return query.Take(number).ToList();
        }
        public bool Update(Article newArticle)
        {
            Article nowArticle = db.Article.Single(x => x.article_id == newArticle.article_id);
            db.Entry(nowArticle).CurrentValues.SetValues(newArticle);//更新
            return db.SaveChanges()>0;

           
        }
    }
}
