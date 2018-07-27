
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
        public IEnumerable<Member> Select(Member m)
        {
            var query = from an in db.Member
                        where
                         (0==m.member_id || an.member_id == m.member_id) &&
                        (string.IsNullOrEmpty(m.member_name)|| an.member_name == m.member_name) &&
                        (string.IsNullOrEmpty(m.member_password)|| an.member_password==m.member_password)
                        
                        select an;
            return query.ToList();
          
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

        public bool Update(Member m)
        {
            Member mModel = db.Member.Single(x => x.member_id == m.member_id);
            mModel.member_name = m.member_name;
            mModel.member_nickname = m.member_nickname;
            if (string.IsNullOrEmpty(m.member_password))
            {
                mModel.member_password = m.member_password;
            }
            mModel.muser = m.muser;
            mModel.mdate = m.mdate;

            db.Entry(mModel).CurrentValues.SetValues(mModel);
            return db.SaveChanges() > 0;
        }
    }    
}
