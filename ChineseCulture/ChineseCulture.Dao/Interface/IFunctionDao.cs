using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao.Interface
{
    public interface IFunctionDao
    {
        bool Add(function fun);
         IEnumerable<function> Select(function fun);
        bool Delete(function fun);
        bool Update(function fun);
    }
}
