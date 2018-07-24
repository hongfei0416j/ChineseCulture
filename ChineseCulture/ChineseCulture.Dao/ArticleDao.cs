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
            return db.SaveChanges()>0;
        }

        public bool Delete(Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> Select(Article article)
        {
            int article_id = article.article_id;
            var query = db.Article.Where(t=>t.category_id==0||t.category_id==0&&t.article_id==0||t.article_id==article_id).OrderBy(s=>s.article_sort);
            return query.ToList();
        }

        public bool Update(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
