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
            string result="";
            switch (symbol)
            {
                case "sqr":
                    if(IsScienceCount(ToDouble(param))|| IsScienceCount(ToDouble(param) * ToDouble(param)))
                    {
                        result = (ToDouble(param) * ToDouble(param)).ToString().ToLower();
                    }
                    else
                    {
                        result = (ToDecimal(param) * ToDecimal(param)).ToString();
                    }                   
                    break;
                case "squareroot":
                    if (param.StartsWith("-"))
                    {
                        return "无效输入";
                    }
                    else
                    {
                        if (IsScienceCount(ToDouble(param)) || IsScienceCount(Math.Sqrt(ToDouble(param))))
                            result = Math.Sqrt(ToDouble(param)).ToString().ToLower();
                        else
                            result= Sqrt(ToDecimal(param)).ToString();                                                               
                        break;
                    }
                case "reverse":
                    if (IsScienceCount(ToDouble(param)) || IsScienceCount(ToDouble(param) * -1))
                        result = (ToDouble(param) * -1).ToString().ToLower();
                    else
                        result = Decimal.Negate(ToDecimal(param)).ToString();                        
                    break;
                case "reciprocal":
                    if (param == "0")
                    {
                        return "除数不能为零";
                    }
                    else
                    {
                        if (IsScienceCount(ToDouble(param)) || IsScienceCount(1 / ToDouble(param)))
                            result = (1 / ToDouble(param)).ToString().ToLower();
                        else
                            result = (1/ToDecimal(param)).ToString();
                        break;
                    }
            }
            return result;
        }

        //计算decimal数值的平方根
        public static decimal Sqrt(decimal d)
        {
            decimal x = d / 3;
            decimal lastX = 0m;
            for (int i = 0; i < 50; i++)
            {
                x = (d / (x * 2)) + (x / 2);
                if (x == lastX) break;
                lastX = x;
            }
            return x;
        }

        public static bool IsScienceCount(double num)
        {
            if (num > 9999999999999999 || num < -9999999999999999)
                return true;
            else
                return false;
        }



    }
}
