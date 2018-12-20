using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace NumberDefine
{
    public static class Filter
    {
        public static string ReturnNum(string resultValue)
        {
            int index = 0;
            if (ToDecimal(resultValue) < 1 && ToDecimal(resultValue) > -1)
                index = 1;
            if (resultValue.Contains(".") && resultValue.StartsWith("-") && resultValue.Length >index+18)
            {
                Debug.WriteLine("执行1");
                return resultValue.Substring(0,index + 18);
            }
            if (resultValue.Length >index+17 && resultValue.Contains(".")&&!resultValue.StartsWith("-"))
            {
                Debug.WriteLine("执行2");
                return resultValue.Substring(0, index + 17);
            }
            if (resultValue.Length > 17 && !resultValue.Contains(".") && resultValue.Contains("-"))
            {
                Debug.WriteLine("执行3");
                return resultValue.Substring(0, 17);
            }
            if (resultValue.Length > 16 && !resultValue.Contains(".") && !resultValue.StartsWith("-"))
            {
                Debug.WriteLine("执行4");
                return resultValue.Substring(0, 16);
            }           
            return resultValue;
        }
    }
}

