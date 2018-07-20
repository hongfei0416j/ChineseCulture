using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class AdminBll
    {
        /// <summary>
        /// 检查是是否登陆成功
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Login(admin user)
        {
            AdminDao adminDao = new AdminDao();

            return adminDao.SelectAdmin(user);
        }
    }
}
