using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class EventHomePageViewModel
    {
        /// <summary>
        /// 赛区组织单位
        /// </summary>
        public IEnumerable<Article>  SaiQuZuZhiDanWei{ set; get; }
        /// <summary>
        /// 赛事获奖榜单
        /// </summary>
        public IEnumerable<Article> SaiShiHuojiangBangdan { get; set; }
        public IEnumerable<ArticleCategory> WenxueZuopinCategoryList { set; get; }
        public IEnumerable<HomeCategoryArticleViewModel> WenxueZuopinCategoryArticleList { set; get; }
        public IEnumerable<ArticleCategory> ShuhuashougongCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> ShuhuashougongCategoryArticleList { get; set; }
        public IEnumerable<ArticleCategory> YishubiaoyanCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> YishubiaoyanCategoryArticleList { get; set; }
        public IEnumerable<ArticleCategory> LonghubangdanCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> LonghubangdanCategoryArticleList { get; set; }
        public List<HomeCategoryArticleViewModel> XueshujiaoliuCategoryArticleList { get; set; }
        public IEnumerable<ArticleCategory> XueshujiaoliuCategoryList { get; set; }
        public IEnumerable<ArticleCategory> LijiesaishiCategoryList { get; set; }
        public List<HomeCategoryArticleViewModel> LijiesaishiCategoryArticleList { get; set; }
    }
}
