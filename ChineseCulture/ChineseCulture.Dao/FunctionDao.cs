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
        public bool Add(Function fun)
        {
            db.Function.Add(fun);
            return db.SaveChanges()>0;
        }

        public bool Delete(Function fun)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Function> Select(Function fun)
        {
            int function_state = fun.function_state;
            int function_id = fun.function_id;
            var query = db.Function.Where(t => t.function_state == function_state && t.function_father_id == function_id).OrderBy(s=>s.function_sort);
           
            return query.ToList();
        }

        public bool Update(Function fun)
        {
            throw new NotImplementedException();
        }
    }
}
