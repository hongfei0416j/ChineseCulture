using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Common
{

    public static class StringHelper
    {
        #region 特殊符號處理方法
        public static string RepStr(this string s_Str)
        {
            if (s_Str.IndexOf("'") > 0)
            {
                s_Str = s_Str.Replace("'", "’");
            }
            if (s_Str.IndexOf("--") > 0)
            {
                s_Str = s_Str.Replace("--", "—");
            }
            return s_Str;
        }
        #endregion

       
        public static string NumberToWord(this string num)
        {
            StringBuilder sbWord = new StringBuilder();
            if (num.Length > 2)
            {
                foreach (char c in num.ToArray())
                {
                    sbWord.Append(c.CharNumberToWord());
                }
            }
            else
            {
                sbWord.Append(num.StringNumberToWord());
            }
            return sbWord.ToString();
        }
        public static char CharNumberToWord(this char num)
        {
            switch (num)
            {
                case '1':
                    return '一';

                case '2':
                    return '二';
                case '3':
                    return '三';
                case '4':
                    return '四';
                case '5':
                    return '五';
                case '6':
                    return '六';
                case '7':
                    return '七';
                case '8':
                    return '八';
                case '9':
                    return '九';
                case '0':
                    return '零';
                case '.':
                    return '點';
                default:
                    return num;
            }
        }
        public static string DateNumberToWord(this string num)
        {
            StringBuilder sbWord = new StringBuilder();
            if (num.Length > 2)
            {
                foreach (char c in num.ToArray())
                {
                    sbWord.Append(c.DateCharNumberToWord());
                }
            }
            else
            {
                sbWord.Append(num.StringNumberToWord());
            }
            return sbWord.ToString();
        }
        public static char DateCharNumberToWord(this char num)
        {
            switch (num)
            {
                case '1':
                    return '一';

                case '2':
                    return '二';
                case '3':
                    return '三';
                case '4':
                    return '四';
                case '5':
                    return '五';
                case '6':
                    return '六';
                case '7':
                    return '七';
                case '8':
                    return '八';
                case '9':
                    return '九';
                case '0':
                    return '○';
                case '.':
                    return '點';
                default:
                    return num;
            }
        }
        public static string StringNumberToWord(this string num)
        {
            switch (num)
            {
                case "0":
                    return "零";
                case "1":
                    return "一";
                case "2":
                    return "二";
                case "3":
                    return "三";
                case "4":
                    return "四";
                case "5":
                    return "五";
                case "6":
                    return "六";
                case "7":
                    return "七";
                case "8":
                    return "八";
                case "9":
                    return "九";
                case "10":
                    return "十";
                case "11":
                    return "十一";
                case "12":
                    return "十二";
                case "13":
                    return "十三";
                case "14":
                    return "十四";
                case "15":
                    return "十五";
                case "16":
                    return "十六";
                case "17":
                    return "十七";
                case "18":
                    return "十八";
                case "19":
                    return "十九";
                case "20":
                    return "二十";
                case "21":
                    return "二十一";
                case "22":
                    return "二十二";
                case "23":
                    return "二十三";
                case "24":
                    return "二十四";
                case "25":
                    return "二十五";
                case "26":
                    return "二十六";
                case "27":
                    return "二十七";
                case "28":
                    return "二十八";
                case "29":
                    return "二十九";
                case "30":
                    return "三十";
                case "31":
                    return "三十一";


                default:
                    return num;
            }
        }
    }
}
