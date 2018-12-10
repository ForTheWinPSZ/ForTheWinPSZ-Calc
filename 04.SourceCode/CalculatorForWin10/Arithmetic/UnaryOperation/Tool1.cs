using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace Arithmetic.UnaryOperation
{
    public static class Tool1
    {
        public static string Calculate(string symbol, string param)
        {
            double result = 0;
            switch (symbol)
            {
                case "sqr":
                    result = ToDouble(param) * ToDouble(param);
                    break;
                case "squareroot":
                    if (param.StartsWith("-"))
                    {
                        return "无效输入";
                    }
                    else
                    {
                        result = Math.Sqrt(ToDouble(param));
                        break;
                    }
                case "reverse":
                    result = ToDouble(param) * -1;
                    break;
                case "reciprocal":
                    if (param == "0")
                    {
                        return "除数不能为零";
                    }
                    else
                    {
                        result = 1 / ToDouble(param);
                        break;
                    }
            }
            return result.ToString();
        }
    }
}
