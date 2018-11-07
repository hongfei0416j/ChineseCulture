using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class UserBll
    {
        UserDao userDao = new UserDao();
        public User CheckUserPassword(string username, string password)
        {
            
            var userModel = new User();
            userModel.user_name = username;
            userModel.user_password = password;
            var newModel = userDao.SelectUser(userModel);
            if (userModel==null)
            {
                return null;
            }
            else
            {
                return newModel;
            }
           
        }

        public User CheckUserGenerateCode(string code, string generate_code,string mobile)
        {
            if (generate_code==code)
            {
                var newModel = userDao.SelectUserByMobile(mobile);
                if (newModel!=null)
                {
                    return newModel;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void RegUser(User uModel)
        {
            userDao.AddUser(uModel);
        }

        public void AddUserLoginLog(UserLoginLog ull)
        {
            userDao.AddUserLoginLog(ull);
        }

        public void AddUserSMSLog(SMSLog smsLog)
        {
            userDao.AddUserSmsLog(smsLog);
        }

        public bool CheckCanSendSms(string mobile)
        {
            SMSLog smsLog = new SMSLog() { telephone=mobile};
            return userDao.SelectUserSmsLogByData(smsLog);
        }
    }
}
