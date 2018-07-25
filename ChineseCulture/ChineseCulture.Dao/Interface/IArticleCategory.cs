using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao.Interface
{
    public interface IArticleCategory
    {

        bool Add(ArticleCategory user);
        IEnumerable<ArticleCategory> Select(ArticleCategory article);
        bool Delete(ArticleCategory user);
        bool Update(ArticleCategory user);
    }
}
