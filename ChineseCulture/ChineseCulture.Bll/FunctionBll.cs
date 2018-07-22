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
        FunctionDao funDao = new FunctionDao();
        public List<AdminMenuViewModel> GetAllMenuFunction()
        {
            List<AdminMenuViewModel> adminLayoutViewModel = new List<AdminMenuViewModel>();

            
            var mainFunction = new function();
            mainFunction.function_father_id = 0;
            mainFunction.function_state = 1;
            var functionList = funDao.Select(mainFunction);
            if (functionList.Count()>0)
            {
                foreach (var item in functionList)
                {

                    var chiledFunctions = funDao.Select(item);
                    //新增子节点

                    if (chiledFunctions.Count() > 0)
                    {
                        AdminMenuViewModel m = new AdminMenuViewModel();
                        m.function = item;
                        m.chiledFunction = chiledFunctions;
                        adminLayoutViewModel.Add(m);
                    }

                }
            }
           
            return adminLayoutViewModel;
        }
    }
}
