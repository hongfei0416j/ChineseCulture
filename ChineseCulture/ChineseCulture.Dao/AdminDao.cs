
using ChineseCulture.Dao.Interface;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao
{
    public class AdminDao:IAdminDao
    {
        ChineseCultureDBEntities db;
        public AdminDao()
        {
            db = new ChineseCultureDBEntities();
        }
        public IEnumerable<admin> Select(admin user)
        {
            var query = from an in db.admin
                    where an.admin_name ==user.admin_name &&
                    an.admin_password==user.admin_password
                    select an;
            return query;
          
        }
        public bool Add(admin user)
        {
            db.admin.Add(user);

            return db.SaveChanges() > 0;
        }



        public bool Delete(admin user)
        {
            throw new NotImplementedException();
        }

        public bool Update(admin user)
        {
            throw new NotImplementedException();
        }
    }    
}
