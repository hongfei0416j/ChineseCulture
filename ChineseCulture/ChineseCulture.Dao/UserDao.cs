using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseCulture.Model;

namespace ChineseCulture.Dao
{
    public class UserDao
    {
        ChineseCultureDBEntities db;
        public UserDao()
        {
            db = new ChineseCultureDBEntities();
        }
        public User SelectUser(User userModel)
        {
            var query = db.User.Where(t => (t.user_name == userModel.user_name || t.user_telephone == userModel.user_name) && t.user_password == userModel.user_password).FirstOrDefault();
            return query;
        }
        public bool AddUser(User userModel)
        {
            try
            {
                db.User.Add(userModel);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public User SelectUserByMobile(string mobile)
        {
            var query = db.User.Where(t => t.user_telephone == mobile).FirstOrDefault();
            return query;
        }

        public void AddUserLoginLog(UserLoginLog uModel)
        {
            db.UserLoginLog.Add(uModel);
            db.SaveChanges();

        }

        public void AddUserSmsLog(SMSLog sms)
        {
            db.SMSLog.Add(sms);
            db.SaveChanges();
        }

        public bool SelectUserSmsLogByData(SMSLog smsLog)
        {
            DateTime dtLast = DateTime.Now.AddMinutes(-1);
            var query = db.SMSLog.Where(t=>t.telephone== smsLog.telephone&&t.kdate> dtLast);
            if (query.Count()>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
