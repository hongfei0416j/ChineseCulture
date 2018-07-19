using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class AdminLayoutViewModel
    {
        public List<AdminTopMenu> AdminTopMenuList { set; get; }
        public AdminLayoutViewModel()
        {
            AdminTopMenu menu = new AdminTopMenu();
            
            menu.fuctionName = "菜单1";
            AdminTopMenuList.Add(menu);
        }
    }
    
}
