using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class UserViewModel
    {
       
        public string user_id { set; get; }
        public string password { set; get; }
        public string mobile { set; get; }
        public string username { set; get; }
        public bool isLogin { set; get; }
        public string isLoginButtonShow { set; get; }
        public string isUserShow { set; get; }
        public UserViewModel()
        {
            isUserShow = "hidden";
            isLoginButtonShow = "";
        }
    }
}
