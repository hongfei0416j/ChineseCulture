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
        public ArticlePageViewModel CreateArticleDetailModel(int article_id,int type=0)
        {
            ArticlePageViewModel articleDetailModel = new ArticlePageViewModel();
            try
            {
                ArticleBll acBll = new ArticleBll();
                Article ac = new Article();
                ac.article_id = article_id;
                Article acNew = acBll.GetArticle(ac);
                
                articleDetailModel.articleModel = acNew;

                ArticleCategoryBll acateBll = new ArticleCategoryBll();
                articleDetailModel.ThisArticleCategory = acBll.GetArticleCategoryByArticle(article_id);
                articleDetailModel.ThisArticleFatherCategory = acBll.GetArticleFatherCategoryByArticle(article_id);
                if (0==type)
                {
                    articleDetailModel.articleRightList = acBll.GetArticlePageList(new ArticlePageViewModel { category_id = acNew.category_id, article_state = 1, page_index = 1, page_size = 20 });
                }
                if (1 == type)
                {
                    articleDetailModel.articleRightList = acBll.GetEventArticlePageList(new ArticlePageViewModel { category_id = acNew.category_id, article_state = 1, page_index = 1, page_size = 20 });
                }
                if (2 == type)
                {
                    articleDetailModel.articleRightList = acBll.GetZazhiArticlePageList(new ArticlePageViewModel { category_id = acNew.category_id, article_state = 1, page_index = 1, page_size = 20 });
                }
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            return articleDetailModel;
        }

        public ArticlePageViewModel CreateZazhiListModel(ArticlePageViewModel articlePageViewModel)
        {
            ArticlePageViewModel articleDetailModel = new ArticlePageViewModel();
            ArticleBll acBll = new ArticleBll();
            articleDetailModel.page_size = 20;
            articleDetailModel.page_index = articlePageViewModel.page_index;
            articleDetailModel.articleRightList = acBll.GetZazhiPageList(new ArticlePageViewModel { article_state = 1, page_index = 1, page_size = 15, category_id = articlePageViewModel.category_id });
            articleDetailModel.category_id = articlePageViewModel.category_id;
            articleDetailModel.articlePageList = acBll.GetZazhiPageList(articleDetailModel);

            ArticleCategoryBll categoryBll = new ArticleCategoryBll();
            articleDetailModel.ThisArticleCategory = categoryBll.GetCategory(new ArticleCategory { category_id = articlePageViewModel.ThisArticleCategory.category_id });
            articleDetailModel.ThisArticleFatherCategory = categoryBll.GetCategory(new ArticleCategory { category_id = articlePageViewModel.ThisArticleCategory.category_father_id });
            articleDetailModel.ArticleCategoryList = categoryBll.GetCategoryList(new ArticleCategory { category_father_id = articleDetailModel.ThisArticleCategory.category_father_id });
            return articleDetailModel;
        }

        public ArticlePageViewModel CreateEventListModel(ArticlePageViewModel articlePageViewModel)
        {
            ArticlePageViewModel articleDetailModel = new ArticlePageViewModel();
            ArticleBll acBll = new ArticleBll();
            articleDetailModel.page_size = 20;
            articleDetailModel.page_index = articlePageViewModel.page_index;
            articleDetailModel.articleRightList = acBll.GetEventPageList(new ArticlePageViewModel { article_state = 1, page_index = 1, page_size = 15,category_id=articlePageViewModel.category_id });
            articleDetailModel.category_id = articlePageViewModel.category_id;
            articleDetailModel.articlePageList = acBll.GetEventPageList(articleDetailModel);

            ArticleCategoryBll categoryBll = new ArticleCategoryBll();
            articleDetailModel.ThisArticleCategory = categoryBll.GetCategory(new ArticleCategory { category_id = articlePageViewModel.ThisArticleCategory.category_id });
            articleDetailModel.ThisArticleFatherCategory = categoryBll.GetCategory(new ArticleCategory { category_id = articlePageViewModel.ThisArticleCategory.category_father_id });
            articleDetailModel.ArticleCategoryList = categoryBll.GetCategoryList(new ArticleCategory { category_father_id = articleDetailModel.ThisArticleCategory.category_father_id });
            return articleDetailModel;

        }

        public ArticlePageViewModel CreateUserArticleListModel(ArticlePageViewModel articlePageViewModel)
        {
            ArticlePageViewModel articleDetailModel = new ArticlePageViewModel();
            ArticleBll acBll = new ArticleBll();
            articleDetailModel.page_size = 200;
            articleDetailModel.page_index = articlePageViewModel.page_index;
           
            articleDetailModel.category_id = articlePageViewModel.category_id;
            articleDetailModel.user_id = articlePageViewModel.user_id;
            articleDetailModel.articlePageList = acBll.GetArticlePageList(articleDetailModel);

            
            return articleDetailModel;
        }

        public ArticlePageViewModel CreateArticleListModel(ArticlePageViewModel articlePageViewModel)
        {
            ArticlePageViewModel articleDetailModel = new ArticlePageViewModel();
            ArticleBll acBll = new ArticleBll();
            articleDetailModel.page_size = 20;
            articleDetailModel.page_index = articlePageViewModel.page_index;
            articleDetailModel.articleRightList = acBll.GetArticlePageListOrderByNewId(new ArticlePageViewModel { article_state=1,page_index=1,page_size=20});
            articleDetailModel.category_id = articlePageViewModel.category_id;
            articleDetailModel.articlePageList = acBll.GetArticlePageList(articleDetailModel);

            ArticleCategoryBll categoryBll = new ArticleCategoryBll();
            articleDetailModel.ThisArticleCategory = categoryBll.GetCategory(new ArticleCategory { category_id = articlePageViewModel.ThisArticleCategory.category_id });
            articleDetailModel.ThisArticleFatherCategory = categoryBll.GetCategory(new ArticleCategory { category_id = articleDetailModel.ThisArticleCategory.category_father_id });
            
            articleDetailModel.ArticleCategoryList = categoryBll.GetCategoryList(new ArticleCategory { category_father_id= articleDetailModel.ThisArticleCategory.category_father_id});

            if (articleDetailModel.ThisArticleFatherCategory.category_level>2)
            {
                //ArticleCategory acFather  =  categoryBll.GetCategory(new ArticleCategory { category_id = articleDetailModel.ThisArticleFatherCategory.category_father_id });
                articleDetailModel.FatherBrotherCategoryList = categoryBll.GetCategoryList(new ArticleCategory { category_father_id = articleDetailModel.ThisArticleFatherCategory.category_father_id, category_level = 2 ,category_id= articleDetailModel.ThisArticleFatherCategory.category_id });
            }
            

            return articleDetailModel;

        }
    }
}
