using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    result = ScientificCalculationTool.Mul(param,param);
                    break;
                case "squareroot":
                    if (param.StartsWith("-"))
                    {
                        return "无效输入";
                    }
                    else
                    {
                        if (IsScienceCount(param) )
                            result = Math.Sqrt(ToDouble(param)).ToString().ToLower();
                        else
                            result= Sqrt(ToDecimal(param)).ToString();                                                               
                        break;
                    }
                case "reverse":
                    if (IsScienceCount(param))
                    {
                        result = ScientificCalculationTool.ScientficNum(param);
                        if (result.StartsWith("-"))
                            result = result.Replace("-", "");
                        else
                            result = result.Insert(0, "-");
                    }                        
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
                        result= ScientificCalculationTool.Division("1", param); 
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

        public static bool IsScienceCount(string num)
        {
            Debug.WriteLine("IsScienceCount:"+num);
            num = num.Trim();
            if (num.Contains("e") || num.Contains("E"))
            {
                return true;
            }
            num = num.Replace("-","");

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
