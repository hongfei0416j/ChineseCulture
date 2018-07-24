
using ChineseCulture.Dao.Interface;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao
{
    public class MemberDao:IMemberDao
    {
        ChineseCultureDBEntities db;
        public MemberDao()
        {
            db = new ChineseCultureDBEntities();
        }
        public IEnumerable<Member> Select(Member user)
        {
            var query = from an in db.Member
                        where an.member_name ==user.member_name &&
                    an.member_password == user.member_password
                        select an;
            return query;
          
        }
        public bool Add(Member user)
        {
            db.Member.Add(user);

            return db.SaveChanges() > 0;
        }



        public bool Delete(Member user)
        {
            throw new NotImplementedException();
        }

        public bool Update(Member user)
        {
            throw new NotImplementedException();
        }
    }    
}
