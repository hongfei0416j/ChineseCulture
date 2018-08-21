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
        public List<HomeCategoryArticleViewModel> PeixunjigouFirst { get; set; }
        public List<HomeCategoryArticleViewModel> PeixunjigouDetail { get; set; }
        public List<HomeCategoryArticleViewModel> QiuzhizhaopinFirst { get; set; }
        public List<HomeCategoryArticleViewModel> QiuzhizhaopinDetail { get; set; }
        public List<HomeCategoryArticleViewModel> ZhuanjiajiangshiFirst { get; set; }
        public List<HomeCategoryArticleViewModel> ZhuanjiajiangshiDetail { get; set; }
        public List<HomeCategoryArticleViewModel> XiaoyuanmingrenFirst { get; set; }
        public List<HomeCategoryArticleViewModel> XiaoyuanmingrenDetail { get; set; }
        public List<HomeCategoryArticleViewModel> ChuangyehezuoFirst { get; set; }
        public List<HomeCategoryArticleViewModel> ChuangyehezuoDetail { get; set; }
        public List<Article> Bianminfuwu { get; set; }
        public List<Article> Caifuzhixing { get; set; }
        public List<Article> Yulekuaibao { get; set; }
        public List<Article> Shijiaguanliyuan { get; set; }
        public IEnumerable<Article> ShouyeGundonggonggao { get; set; }
        public IEnumerable<Article> Shouyegundonggonggaotupian { get; set; }
        public IEnumerable<Article> Shouyexuexiaoshipin { get; set; }
        public IEnumerable<Article> Shouyexuexiaotupian { get; set; }
        public IEnumerable<Article> ShouyePeixunjigougundongtupian { get; set; }
        public IEnumerable<Article> ShouyePeixunjigoutupian { get; set; }
        public IEnumerable<Article> ShouyeQiuzhizhaopintupian { get; set; }
        public IEnumerable<Article> ShouyeZhuanjiajiangshigundongtupian { get; set; }
        public IEnumerable<Article> ShouyeZhuanjiajiangshitupian { get; set; }
        public IEnumerable<Article> ShouyeXiaoyuanmingrentupian { get; set; }
        public IEnumerable<Article> Shouyechuangyehezuogundongtupian { get; set; }
        public IEnumerable<Article> Shouyechuangyehezuotupian { get; set; }
        public Article ShouyexuexiaoshipinOne { get; set; }
        public Article ShouyexuexiaoshipinOnePic { get; set; }
    }

}
