using ChineseCulture.Dao;
using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Bll
{
    public class FunctionBll
    {
        FunctionDao funDao;
        public FunctionBll()
        {
            funDao = new FunctionDao();
        }
        public List<AdminMenuViewModel> GetAllMenuFunction()
        {
            List<AdminMenuViewModel> adminLayoutViewModel = new List<AdminMenuViewModel>();
            var mainFunction = new Function();
            mainFunction.function_id = 0;
            mainFunction.function_state = 0;
            mainFunction.function_father_id = 0;
            var functionList = funDao.Select(mainFunction);

            foreach (var item in functionList)
            {
                item.function_father_id = item.function_id;
                item.function_id = 0;
                var chiledFunctions = funDao.Select(item);
                AdminMenuViewModel m = new AdminMenuViewModel();
                m.function = item;
                m.chiledFunction = chiledFunctions;
                adminLayoutViewModel.Add(m);


            }


            return adminLayoutViewModel;
        }

        public IEnumerable<Function> GetAllAdminFatherFunction()
        {
            var allFunction = new Function();
            allFunction.function_id = 0;
            allFunction.function_state = 1;
            allFunction.function_father_id = 0;
            return funDao.Select(allFunction);
        }

        public Function GetFunction(int id)
        {
            var fun = new Function();
           
            fun.function_id = id;
            fun.function_father_id = -1;
            return funDao.Select(fun).FirstOrDefault();
        }

        public void UpdateFunction(Function fun)
        {
            funDao.Update(fun);
        }

        public object GetAllAdminFunction()
        {
            var allFunction = new Function();
            allFunction.function_id = 0;
            allFunction.function_state = 0;
            allFunction.function_father_id=-1;
            return funDao.Select(allFunction);
        }

        public void AddFunction(Function f)
        {
            funDao.Add(f);
        }
    }
}
