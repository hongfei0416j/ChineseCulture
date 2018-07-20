using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Common
{
    public static class CommonFunction
    {
        public static int getWeekNumInMonth(DateTime daytime)
        {
            int dayInMonth = daytime.Day;
            //本月第一天  
            DateTime firstDay = daytime.AddDays(1 - daytime.Day);
            //本月第一天是周几  
            int weekday = (int)firstDay.DayOfWeek == 0 ? 7 : (int)firstDay.DayOfWeek;
            //本月第一周有几天  
            int firstWeekEndDay = 7 - (weekday - 1);
            //当前日期和第一周之差  
            int diffday = dayInMonth - firstWeekEndDay;
            diffday = diffday > 0 ? diffday : 1;
            //当前是第几周,如果整除7就减一天  
            int WeekNumInMonth = ((diffday % 7) == 0
             ? (diffday / 7 - 1)
             : (diffday / 7)) + 1 + (dayInMonth > firstWeekEndDay ? 1 : 0);
            return WeekNumInMonth;
        }
        public static string GetIP4Address(string s)
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(s))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }

            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }

        #region 將DataTable直接轉化為List
        /// <summary>
        /// 將DataTable直接轉化為List<model>
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dt) where T : new()
        {
            List<T> ilResult = new List<T>();
            IList<PropertyInfo> ilPropertyInfo = typeof(T).GetProperties();
            foreach (DataRow dr in dt.Rows)
            {
                T m = new T();
                foreach (var p in ilPropertyInfo)
                {
                    if (dt.Columns[p.Name] == null)
                    {
                        continue;
                    }
                    SetValue(m, p.Name, dr[p.Name]);

                }
                ilResult.Add(m);
            }
            return ilResult;

        }
        public static void SetValue(object inputObject, string propertyName, object propertyVal)
        {

            Type type = inputObject.GetType();

            System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName);

            Type propertyType = propertyInfo.PropertyType;

            var targetType = IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;

            propertyVal = Convert.ChangeType(propertyVal, targetType);

            propertyInfo.SetValue(inputObject, propertyVal, null);

        }
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
        #endregion
    }
}
