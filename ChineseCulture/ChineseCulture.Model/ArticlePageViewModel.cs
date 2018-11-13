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
        public int page_size { get; set; }
        public int category_id { get; set; }
        public int article_state { get; set; }
        public int article_id { get; set; }
        public PagedList<Article> articleRightList { get; set; }
        public ArticleCategory ThisArticleCategory { get; set; }
        public ArticleCategory ThisArticleFatherCategory { get; set; }
        public IEnumerable<ArticleCategory> ArticleCategoryList { get; set; }
        public string user_id { set; get; }
    }
}
