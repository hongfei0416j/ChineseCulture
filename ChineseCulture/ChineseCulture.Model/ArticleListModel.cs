using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class ArticleListModel
    {
        public string dateStart { set; get; }
        public string dateEnd { set; get; }
        public int category_id { set; get; }
        public string article_title { set; get; }
        public List<Article> articleList { set; get; }

        public int allCount { set; get; }


    }
}
