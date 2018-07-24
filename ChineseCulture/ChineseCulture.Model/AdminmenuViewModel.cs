using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class AdminMenuViewModel
    {
       public Function function { set; get; }
        public IEnumerable<Function> chiledFunction { set; get; }

        public AdminMenuViewModel()
        {
            function = new Function();
          
        }
    }
    
}
