using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace Arithmetic.BinaryOperaion
{
    public static class Tool
    {
        public static string Compute(string num1, string symbol, string num2)
        {
            double result = 0;
            switch (symbol)
            {
                case "+":
                    result = ToDouble(num1) + ToDouble(num2);
                    break;
                case "-":
                    result = ToDouble(num1) - ToDouble(num2);
                    break;
                case "×":
                    result = ToDouble(num1) * ToDouble(num2);
                    break;
                case "÷":
                    if (num2 == "0")
                        return "除数不能为零";
                    result = ToDouble(num1) / ToDouble(num2);
                    break;
            }
            return result.ToString();
        }
    }
}
