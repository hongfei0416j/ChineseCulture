using ChineseCulture.Dao.Interface;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao
{
    public class FunctionDao : IFunctionDao
    {
        ChineseCultureDBEntities db;
        public FunctionDao()
        {
            db = new ChineseCultureDBEntities();
        }
        public bool Add(function fun)
        {
            throw new NotImplementedException();
        }

        public bool Delete(function fun)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<function> Select(function fun)
        {
            var query = (from f in db.function
                       
                        select f).ToList();
            if (query.Count>0)
            {

            }
            return query.ToList();
        }

        public bool Update(function fun)
        {
            throw new NotImplementedException();
        }
    }
}
