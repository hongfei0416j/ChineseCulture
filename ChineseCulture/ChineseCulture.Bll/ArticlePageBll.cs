using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Webdiyer.WebControls.Mvc;

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

        public ArticlePageViewModel CreateArticleListModel()
        {
            ArticlePageViewModel articleDetailModel = new ArticlePageViewModel();
            ArticleBll acBll = new ArticleBll();
           
            articleDetailModel.articlePageList = new PagedList<Article>(acBll.GetAllArticle(),1,10);
            return articleDetailModel;

        }
    }
}
