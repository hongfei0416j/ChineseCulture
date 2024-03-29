﻿using ChineseCulture.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Dao.Interface
{
    public interface IFunctionDao
    {
        bool Add(Function fun);
         IEnumerable<Function> Select(Function fun);
        bool Delete(Function fun);
        bool Update(Function fun);
    }
}
