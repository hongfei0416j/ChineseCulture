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
    }
}
