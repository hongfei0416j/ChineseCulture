using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class ArticlePageBll
    {
        public ArticlePageViewModel acPageModel;
        public ArticlePageBll()
        {

        }
        public ArticlePageViewModel CreateArticleDetailModel(int article_id)
        {
            ArticlePageViewModel articleDetailModel = new ArticlePageViewModel();
            try
            {
                ArticleBll acBll = new ArticleBll();
                Article ac = new Article();
                ac.article_id = article_id;
                Article acNew = acBll.GetArticle(ac);

                articleDetailModel.articleModel = acNew;
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            return articleDetailModel;
        }
    }
}
