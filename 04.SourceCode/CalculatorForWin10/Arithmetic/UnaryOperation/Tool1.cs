using Arithmetic.BinaryOperaion;
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
                        if (Tool.IsScienceCount(param) )
                            result = ScientificSqrt(param);
                        else
                            result= Sqrt(ToDecimal(param)).ToString();                                                               
                        break;
                    }
                case "reverse":
                    if (param.Equals("0")||param=="")
                        result = "0";
                    else if (param.StartsWith("-"))
                        result = param.Replace("-", "");
                    else
                        result = param.Insert(0, "-");                                      
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
                case "cube":
                    result =ScientificCalculationTool.Mul(param, ScientificCalculationTool.Mul(param, param)) ;
                    break;
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
        //计算科学计数的平方根
        public static string ScientificSqrt(string d)
        {
            string x = ScientificCalculationTool.Division(d, "3");
            string lastX = "";
            for(int i = 0; i < 50; i++)
            {
                x = Tool.Compute(Tool.Compute(d, "÷", Tool.Compute(x, "+", x)), "+", Tool.Compute(x, "÷", "2"));
                if (x.Equals(lastX)) break;
                lastX = x;
            }
            return x;
        }


    }
}
