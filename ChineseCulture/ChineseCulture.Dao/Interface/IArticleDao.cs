using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao.Interface
{
    public interface IArticleDao
    {
        bool Add(Article user);
        IEnumerable<Article> Select(Article article);
        bool Delete(Article user);
        bool Update(Article user);
    }
}
