using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Model
{
    public class AdminMenuViewModel
    {
       public function function { set; get; }
        public List<function> chiledFunction { set; get; }

        public AdminMenuViewModel()
        {
            function = new function();
            chiledFunction = new List<function>();
        }
    }
    
}
