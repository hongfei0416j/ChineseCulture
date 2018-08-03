using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class HomePageViewModel
    {
        public IEnumerable<Article> zixuekaoshi;

        /// <summary>
        /// 网站公告
        /// </summary>
        public IEnumerable<Article> WangzhanGonggao { set; get; }
        public IEnumerable<Article> Zuixinzixun { get; set; }
        public IEnumerable<Article> Wenxuezuopin { get; set; }
       
        public List<HomeCategoryArticleViewModel> XuexiaoFirst { get; set; }
        public List<HomeCategoryArticleViewModel> XuexiaoDetail { get; set; }
    }

}
