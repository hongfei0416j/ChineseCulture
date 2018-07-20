using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseCulture.Interface
{
     public interface IAdmin
    {
         bool Add(admin user);
        bool Select(admin user);
        bool Delete(admin user);
        bool Update(admin user);
    }
}
