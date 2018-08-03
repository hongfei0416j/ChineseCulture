using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class HomeCategoryArticleViewModel
    {
        public string category_name { set; get; }
        public IEnumerable<Article> articleList { set; get; }
        public IEnumerable<Article> homeArticleList { set; get; }
        public Article adArticle { set; get; }
    }
}
