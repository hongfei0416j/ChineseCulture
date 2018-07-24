using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao.Interface
{
    public interface IMemberDao
    {
        bool Add(Member user);
        IEnumerable<Member> Select(Member user);
        bool Delete(Member user);
        bool Update(Member user);
    }
}
