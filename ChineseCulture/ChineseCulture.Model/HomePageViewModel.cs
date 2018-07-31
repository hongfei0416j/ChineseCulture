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
        public IEnumerable<Article> Quanrizhi { get; set; }
        public IEnumerable<Article> chengrenjiaoyu { get; set; }
        public IEnumerable<Article> youeryuan { get; set; }
        public IEnumerable<Article> zaojiao { get; set; }
        public IEnumerable<Article> xueqianban { get; set; }
        public IEnumerable<Article> xiaoxue { get; set; }
        public IEnumerable<Article> chuzhong { get; set; }
        public IEnumerable<Article> gaozhong { get; set; }
        public IEnumerable<Article> daxue { get; set; }
        public IEnumerable<Article> zhiyeyuanxiao { get; set; }
        public IEnumerable<Article> teshujiaoyu { get; set; }
    }

}
