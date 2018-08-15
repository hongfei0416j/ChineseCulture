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
        
    }
}
