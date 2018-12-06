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
            switch (symbol)
            {
                case "square":
                    return (ToDouble(param) * ToDouble(param)).ToString().ToLower();
                    
                case "squareroot":
                    if (param.StartsWith("-"))
                    {
                        return "无效输入";
                    }
                    else
                    {
                        //开方
                        return Math.Sqrt(ToDouble(param)).ToString().ToLower();
                    }
                  
                case "reverse":
                    return (ToDouble(param) * -1).ToString().ToLower();
                 
                case "reciprocal":
                    if (param == "0")
                    {
                        return "除数不能为零";
                    }
                    else
                    {
                        //倒数
                        return (1 / ToDouble(param)).ToString().ToLower();
                    }
                 
            }
            return "";
        }
    }
}
