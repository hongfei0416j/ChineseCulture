using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao.Interface
{
    public interface IAdminDao
    {
        bool Add(admin user);
        bool Select(admin user);
        bool Delete(admin user);
        bool Update(admin user);
    }
}
