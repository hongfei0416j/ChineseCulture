
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
        public bool SelectAdmin(admin user)
        {
            var query = from an in db.admin
                    where an.admin_name ==user.admin_name &&
                    an.admin_password==user.admin_password
                    select an;
            return query.Count() > 0;
          
        }
      
      

       
        bool IAdminDao.Add(admin user)
        {
            db.admin.Add(user);

            return db.SaveChanges() > 0;
        }

        bool IAdminDao.Select(admin user)
        {
            throw new NotImplementedException();
        }

        bool IAdminDao.Delete(admin user)
        {
            throw new NotImplementedException();
        }

        bool IAdminDao.Update(admin user)
        {
            throw new NotImplementedException();
        }
    }    
}
