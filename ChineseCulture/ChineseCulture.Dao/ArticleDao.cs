using ChineseCulture.Dao.Interface;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

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
            (string.IsNullOrEmpty(article.article_title)||t.article_title==article.article_title)&&
            (article_id==0||t.article_id==article_id)).OrderBy(t=>t.article_sort).OrderByDescending(s=>s.article_mdate);
            return query.ToList();
        }

        public PagedList<Article> SelectOrderByNewId(int number)
        {


            var query = db.Article.Where(t=>1==1).OrderBy(o => Guid.NewGuid()).Take(number);
            return query.ToPagedList<Article>(1, number);
        }

        public IEnumerable<Article> Select(Article article,int number)
        {
            int article_id = article.article_id;
            int category_id = article.category_id;
            int article_state = article.article_state;

            var query = db.Article.Where(t =>
            (category_id == 0 || t.category_id == category_id) &&
            (article_state == 0 || t.article_state == article_state) &&
            (article_id == 0 || t.article_id == article_id)).OrderByDescending(s => s.article_mdate).OrderBy(t => t.article_sort);
            return query.Take(number).ToList();
        }
        public bool Update(Article newArticle)
        {
            Article nowArticle = db.Article.Single(x => x.article_id == newArticle.article_id);
            newArticle.article_kuser = nowArticle.article_kuser;
            newArticle.article_kdate = nowArticle.article_kdate;

            db.Entry(nowArticle).CurrentValues.SetValues(newArticle);//更新
            return db.SaveChanges()>0;

           
        }
        public bool Refrush(Article newArticle)
        {
            Article nowArticle = db.Article.Single(x => x.article_id == newArticle.article_id);
            nowArticle.article_muser = newArticle.article_muser;
            nowArticle.article_mdate = newArticle.article_mdate;

            db.Entry(nowArticle).CurrentValues.SetValues(nowArticle);//更新
            return db.SaveChanges() > 0;


        }
        public PagedList<Article> SelectPageList(ArticlePageViewModel articleDetailModel)
        {
            var query = db.Article.Where(t =>
            (string.IsNullOrEmpty(articleDetailModel.user_id) || t.article_kuser == articleDetailModel.user_id) &&
            (articleDetailModel.category_id == 0 || t.category_id == articleDetailModel.category_id) &&
            (articleDetailModel.article_state == 0 || t.article_state == articleDetailModel.article_state) &&
            (articleDetailModel.article_id == 0 || t.article_id == articleDetailModel.article_id)).OrderBy(t => t.article_sort).OrderByDescending(s => s.article_mdate);
            return query.ToPagedList<Article>(articleDetailModel.page_index, articleDetailModel.page_size);
        }

        public void UpdateTickOfArticle(ArticleTicks at)
        {
            var article =  db.Article.Where(t=>t.article_id==at.article_id).FirstOrDefault();
            article.tick_number = article.tick_number + 1;
            db.SaveChanges();
        }

        public bool AddArticleTick(ArticleTicks at)
        {
            //var 
            try
            {
                db.ArticleTicks.Add(at);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Article> SelectByCategory(Article article, int number, ArticleCategory ac)
        {
            int category_father_id = ac.category_father_id;

            var query = from t in db.ArticleCategory
                        join a in db.Article on t.category_id equals article.category_id
                        where t.category_father_id == category_father_id
                        orderby t.category_sort,a.article_sort
                         select a;
            return query.Take(number).ToList();
            //var query = db.Article.Where(t =>
            //(category_id == 0 || t.category_id == category_id) &&
            //(article_state == 0 || t.article_state == article_state) &&
            //(article_id == 0 || t.article_id == article_id)).OrderBy(t => t.article_sort).OrderByDescending(s => s.article_kdate);
            //return query.Take(number).ToList();
        }
    }
}
