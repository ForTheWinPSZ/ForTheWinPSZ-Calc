using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine("num1:" + num1);
            Debug.WriteLine("num2:" + num2);
            string result = "";
            switch (symbol)
            {
                case "+":
                    if( IsScienceCount(num1) || IsScienceCount(num2))
                    {
                        result = ScientificCalculationTool.Plus(num1,num2);
                    }
                    else
                    {                       
                        result = (ToDecimal(num1) + ToDecimal(num2)).ToString();
                        if (IsScienceCount(result))
                            result = ScientificCalculationTool.ScientficNum(result);
                    }
                    
                    break;
                case "-":
                    if (IsScienceCount(num1) || IsScienceCount(num2))
                    {
                        if (num2.StartsWith("-"))
                            num2 = num2.Replace("-", "");
                        else
                            num2 = num2.Insert(0, "-");
                        result = ScientificCalculationTool.Plus(num1, num2);
                    }
                    else
                    {
                        result = (ToDecimal(num1) - ToDecimal(num2)).ToString();
                        if (IsScienceCount(result))
                            result = ScientificCalculationTool.ScientficNum(result);
                    }
                    break;
                case "×":
                    result = ScientificCalculationTool.Mul(num1, num2);
                    break;
                case "÷":
                    if (num1 == "除数不能为零")
                        return "0";
                    if (num2 == "0")
                        return "除数不能为零";
                    result = ScientificCalculationTool.Division(num1, num2);
                    break;
            }
            return result;
        }

        public static bool IsScienceCount(string num)
        {
            Debug.WriteLine("IsScienceCount:" + num);
            num = num.Trim();
            if (num.Contains("e") || num.Contains("E"))
            {
                return true;
            }
            
            num = num.Replace("-", "");
            if (num.Equals("0"))
                return false;
            if (ToDecimal(num) >= 10000000000000000)
                return true;
            if (ToDecimal(num) < 0.0000000000000001m)
                return true;
            if (ToDecimal(num) < 0.00000001m && num.Length > 18)
                return true;
            if (ToDecimal(num) < 0.001m && num.Length >= 26)
                return true;
            return false;
        }


       
    }
}
