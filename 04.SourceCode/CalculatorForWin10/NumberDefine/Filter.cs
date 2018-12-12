using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public static class Filter
    {
        public static string returnNum(string resultValue)
        {

            if (resultValue.Contains(".") && resultValue.Contains("-") && resultValue.Length > 18)
            {
                return resultValue.Substring(0, 18);
            }
            if (resultValue.Length > 17 && (resultValue.Contains(".") || resultValue.Contains("-")))
            {
                return resultValue.Substring(0, 17);
            }
            if (resultValue.Length > 16)
            {
                return resultValue.Substring(0, 16);
            }
            return resultValue;
        }
    }
}

