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
            mainFunction.function_state = 1;
            var functionList = funDao.Select(mainFunction);

            foreach (var item in functionList)
            {

                var chiledFunctions = funDao.Select(item);
                AdminMenuViewModel m = new AdminMenuViewModel();
                m.function = item;
                m.chiledFunction = chiledFunctions;
                adminLayoutViewModel.Add(m);


            }


            return adminLayoutViewModel;
        }

        public object GetFunction(int id)
        {
            var fun = new Function();
           
            fun.function_id = id;
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
            allFunction.function_state = 1;
            return funDao.Select(allFunction);
        }

        public void AddFunction(Function f)
        {
            funDao.Add(f);
        }
    }
}
