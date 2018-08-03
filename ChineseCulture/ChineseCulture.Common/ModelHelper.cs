using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Common
{
    public static class ModelHelper
    {
        public static object ModelSupplement(object o)
        {
            Type t = o.GetType();
            var properties = t.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType == typeof(int))
                {
                    if (null == properties[i].GetValue(o, null))
                    {
                        properties[i].SetValue(o, 0, null);
                    }

                }
                if (properties[i].PropertyType == typeof(string))
                {
                    if (null == properties[i].GetValue(o, null))
                    {
                        properties[i].SetValue(o, "", null);
                    }

                }
            }
            return o;
        }
    }
}
