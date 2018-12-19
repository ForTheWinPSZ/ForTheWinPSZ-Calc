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
            if (ToDecimal(num) == 0)
                return false;
            num = num.Replace("-", "");

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


        #region 限制输出框最大容纳位数,这里仅供存入表达式与历史记录使用
        public static string MaxContain(string resultValue)
        {            
            char[] strs = { '不', '无', '未', '溢' };
            if (resultValue==null||resultValue == "" || resultValue.IndexOfAny(strs)!=-1)
                return resultValue;
            //科学记数法暂时不作取舍
            if (resultValue.Contains("e") || resultValue.Contains("E"))
                return ScientificCalculationTool.DisplayScientficNum(resultValue);
            
            
            //判断是否为0.
            int index;
            if (ToDecimal(resultValue) < 1 && ToDecimal(resultValue) > -1)
                index = 1;
            else
                index = 0;
            //有点有负号
            if (resultValue.Contains(".") && resultValue.StartsWith("-") && resultValue.Length > index + 18)
            {
                Debug.WriteLine("index:" + index);
                resultValue = Rounding2(resultValue, index + 18);              
            }
            //有点无负号
            else if (resultValue.Length > index + 17 && resultValue.Contains(".") && !resultValue.StartsWith("-"))
            {
                Debug.WriteLine("resultValue:" + resultValue);
                resultValue = Rounding2(resultValue, index + 17);                         
            }
            //无点有负号
            else if (resultValue.Length > 17 && !resultValue.Contains(".") && resultValue.StartsWith("-"))
            {
                resultValue = Rounding2(resultValue, 17);                
            }
            //无点无负号
            else if (resultValue.Length > 16 && !resultValue.Contains(".") && !resultValue.StartsWith("-"))
            {
                resultValue = Rounding2(resultValue, 16);               
            }           
            //去掉小数后面多余的0和点
            if (resultValue.Contains("."))
                resultValue = resultValue.TrimEnd('0');
            //去掉尾数的点
            if (resultValue.EndsWith("."))
                resultValue = resultValue.TrimEnd('.');           
            return resultValue;
        }
        #endregion

        public static string Rounding2(string resultValue, int num)
        {
            string value1 = resultValue.Substring(0, num);
            string value2 = "";
            if (resultValue.Substring(num, 1).Equals("."))
                value2 = resultValue.Substring(num+1, 1);
            else
                value2 = resultValue.Substring(num, 1);
            if (ToDouble(value2) >= 5)
            {
                string mm = "";
                char[] arr = value1.ToCharArray();
                for (int i = arr.Length - 1; i >= 0; i--)
                {

                    if (arr[i] == '.')
                        continue;
                    if (arr[i] != '9')
                    {
                        int a = ToInt32(arr[i]) - 47;
                        arr[i] = char.Parse(a.ToString());
                        break;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            mm = "1";
                        }
                        arr[i] = '0';
                    }

                }
                return mm + new string(arr);
            }
            else
            {
                return value1;
            }
        }
    }
}
