using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace ChineseCulture.Model
{
    public class ArticlePageViewModel
    {
        public Article articleModel { set; get; }
        public IEnumerable<Article> articleList { set; get; }
        public int page_number { set; get; }
        public int page_index { set; get; }
        public int page_count { set; get; }
        public PagedList<Article> articlePageList{ set; get; }
}
}
