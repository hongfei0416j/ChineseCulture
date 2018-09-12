using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class WenyizazhiHomePageViewModel
    {
        

        public IEnumerable<Article> Zazhishouyegundongtupian { get; set; }
        public IEnumerable<Article> zazhi_bennianduliangqihuojiangxuanshoumingdan { get; set; }
        public IEnumerable<Article> zazhi_zuixinzazhi { get; set; }
        public IEnumerable<Article> zazhi_mingrentuijian { get; set; }
        public IEnumerable<Article> zazhi_wenyixinxiu { get; set; }
        public IEnumerable<ArticleCategory> MingjiafengcaiCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> MingjiafengcaiCategoryArticleList { get; set; }
        public List<HomeCategoryArticleViewModel> MhuohongnianhuaCategoryArticleList { get; set; }
        public IEnumerable<ArticleCategory> huohongnianhuaCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> qingchunxiaoyuanCategoryArticleList { get; set; }
        public IEnumerable<ArticleCategory> qingchunxiaoyuanCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> huohongnianhuaCategoryArticleList { get; set; }
        public IEnumerable<ArticleCategory> guxiangzhilianCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> guxiangzhilianCategoryArticleList { get; set; }
        public IEnumerable<ArticleCategory> fangfeimengxiangCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> fangfeimengxiangCategoryArticleList { get; set; }
        public IEnumerable<ArticleCategory> huojiangzuopinCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> huojiangzuopinCategoryArticleList { get; set; }
    }
}
