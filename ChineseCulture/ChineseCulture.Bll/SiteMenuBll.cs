using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class SiteMenuBll
    {
        SiteMenuDao smDao;
        public SiteMenuBll()
        {
            smDao = new SiteMenuDao();
        }
        public IEnumerable<SiteMenu> SelectAllMenu()
        {
            SiteMenu sm = new SiteMenu();
            return smDao.Select(sm);
        }

        public IEnumerable<SiteMenu> GetAllMenuFather()
        {
            SiteMenu sm = new SiteMenu();
            sm.menu_father_id = 1;
            sm.menu_state = 1;
            return smDao.Select(sm);
        }

        public void AddSiteMenu(SiteMenu sm)
        {
            smDao.Add(sm);
        }
    }
}
