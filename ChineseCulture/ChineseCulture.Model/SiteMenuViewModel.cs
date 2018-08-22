using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class SiteMenuViewModel
    {
        public string menu_name { set; get; }
        public IEnumerable<SiteMenu> siteMenuList { set; get; }
    }
}
