using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao
{
    public class SiteMenuDao
    {
        ChineseCultureDBEntities db;
        public SiteMenuDao()
        {
            db = new ChineseCultureDBEntities();
        }
        public IEnumerable<SiteMenu> Select(SiteMenu sm)
        {
            var query = db.SiteMenu.Where(t => 
            (sm.menu_state == 0||t.menu_state==t.menu_state)
            &&(sm.menu_father_id==0||t.menu_father_id==sm.menu_father_id)
            && (string.IsNullOrEmpty(sm.menu_category) || t.menu_category == sm.menu_category)
            ).OrderBy(t=>t.menu_sort).ToList();
            return query;
        }

        public void Add(SiteMenu sm)
        {
            db.SiteMenu.Add(sm);
            db.SaveChanges();
        }
    }
}
