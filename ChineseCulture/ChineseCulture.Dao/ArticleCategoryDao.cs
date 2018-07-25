using ChineseCulture.Dao.Interface;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao
{
    public class ArticleCategoryDao : IArticleCategory
    {
        ChineseCultureDBEntities db;
        public ArticleCategoryDao()
        {
            db = new ChineseCultureDBEntities();
        }
        public bool Add(ArticleCategory user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ArticleCategory user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleCategory> Select(ArticleCategory article)
        {
            int category_state = article.category_state;
            int categry_father_id = article.category_father_id;
            int category_id = article.category_id;
            string category_code = article.category_code;

            var query = db.ArticleCategory.Where(t => (category_state == 0 || t.category_state == 1) &&
           (categry_father_id == 0 || t.category_father_id == categry_father_id) &&
           (category_id == 0 || t.category_id == category_id) &&
           (string.IsNullOrEmpty(category_code)||article.category_code==category_code)
            ).OrderBy(t=>t.category_sort);
            return query.ToList();
        }

        public bool Update(ArticleCategory user)
        {
            throw new NotImplementedException();
        }
    }
}
