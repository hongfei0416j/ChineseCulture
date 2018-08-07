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
                articleDetailModel.articleRightList = acBll.GetArticlePageList(new ArticlePageViewModel { article_state=1,page_index=1,page_size=15});
                articleDetailModel.articleModel = acNew;
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            return articleDetailModel;
        }

        public ArticlePageViewModel CreateArticleListModel(int page_index=0)
        {
            ArticlePageViewModel articleDetailModel = new ArticlePageViewModel();
            ArticleBll acBll = new ArticleBll();
            articleDetailModel.page_size = 20;
            articleDetailModel.page_index = page_index;
            articleDetailModel.articleRightList = acBll.GetArticlePageList(articleDetailModel);
            articleDetailModel.articlePageList = acBll.GetArticlePageList(articleDetailModel);
            
            return articleDetailModel;

        }
    }
}
