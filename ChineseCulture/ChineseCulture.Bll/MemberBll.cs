using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class MemberBll
    {
         MemberDao memberDao;
        public MemberBll()
        {
            memberDao = new MemberDao();
        }
        /// <summary>
        /// 
        /// 检查是是否登陆成功
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Login(Member user)
        {
            if (string.IsNullOrEmpty(user.member_name)||string.IsNullOrEmpty(user.member_password))
            {
                return false;
            }
            return memberDao.Select(user).Count()>0;
        }

        public void AddMember(Member m)
        {
            memberDao.Add(m);
        }

        public dynamic GetAllMember()
        {
            Member m = new Member();
            return memberDao.Select(m);
        }

        public Member GetMemberNyid(int id)
        {
            Member m = new Member();
            m.member_id = id;
            return memberDao.Select(m).FirstOrDefault();
        }

        public void UpdateMember()
        {
            throw new NotImplementedException();
        }

        public void UpdateMember(Member m)
        {
            memberDao.Update(m);
        }
    }
}
