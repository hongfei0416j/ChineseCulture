using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class HomePageViewModel
    {
        /// <summary>
        /// 网站公告
        /// </summary>
        public IEnumerable<Article> WangzhanGonggao { set; get; }
        
    }

}
