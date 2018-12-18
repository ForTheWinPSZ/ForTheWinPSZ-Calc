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
                    if( IsScienceCount(ToDouble(num1)) || IsScienceCount(ToDouble(num2)) || IsScienceCount(ToDouble(num1) + ToDouble(num2)))
                    {
                        result = (ToDouble(num1) + ToDouble(num2)).ToString().ToLower();
                    }
                    else
                    {
                        result = (ToDecimal(num1) + ToDecimal(num2)).ToString();
                    }
                    
                    break;
                case "-":
                    if (IsScienceCount(ToDouble(num1)) || IsScienceCount(ToDouble(num2)) || IsScienceCount(ToDouble(num1) - ToDouble(num2)))
                    {
                        result = (ToDouble(num1) - ToDouble(num2)).ToString().ToLower();
                    }
                    else
                    {
                        result = (ToDecimal(num1) - ToDecimal(num2)).ToString();
                    }
                    break;
                case "×":
                    if (IsScienceCount(ToDouble(num1)) || IsScienceCount(ToDouble(num2)) || IsScienceCount(ToDouble(num1) * ToDouble(num2)))
                    {
                        result = (ToDouble(num1) * ToDouble(num2)).ToString().ToLower();
                    }
                    else
                    {
                        result = (ToDecimal(num1) * ToDecimal(num2)).ToString();
                    }
                    break;
                case "÷":
                    if (num1 == "除数不能为零")
                        return "0";
                    if (num2 == "0")
                        return "除数不能为零";
                    if (IsScienceCount(ToDouble(num1)) || IsScienceCount(ToDouble(num2)) || IsScienceCount(ToDouble(num1) / ToDouble(num2)))
                    {
                        result = (ToDouble(num1) / ToDouble(num2)).ToString().ToLower();
                    }
                    else
                    {
                        result = (ToDecimal(num1) / ToDecimal(num2)).ToString();
                    }
                    break;
            }
            return result;
        }

        public static bool IsScienceCount(double num)
        {
           
            if (num > 9999999999999999 || num < -9999999999999999)
            {
                
                return true;
            }

            else
            {
                
                return false;
            }
                
        }
        #region 限制输出框最大容纳位数
        public static string MaxContain(string resultValue)
        {
            Debug.WriteLine("MaxContain:"+resultValue);
            if (resultValue==null||resultValue == "" || resultValue.Contains("不") || resultValue.Contains("无") || resultValue.Contains("未"))
                return resultValue;
            //科学记数法暂时不作取舍
            if (resultValue.Contains("e") || resultValue.Contains("E"))
                return resultValue;
            
            
            //判断是否为0.
            int index;
            if (ToDouble(resultValue) < 1 && ToDouble(resultValue) > -1)
                index = 1;
            else
                index = 0;
            //有点有负号
            if (resultValue.Contains(".") && resultValue.Contains("-") && resultValue.Length > index + 18)
            {
                Debug.WriteLine("index:" + index);
                resultValue = Rounding2(resultValue, index + 18);              
            }
            //有点无负号
            else if (resultValue.Length > index + 17 && resultValue.Contains(".") && !resultValue.Contains("-"))
            {
                Debug.WriteLine("resultValue:" + resultValue);
                resultValue = Rounding2(resultValue, index + 17);                         
            }
            //无点有负号
            else if (resultValue.Length > 17 && !resultValue.Contains(".") && resultValue.Contains("-"))
            {
                resultValue = Rounding2(resultValue, 17);                
            }
            //无点无负号
            else if (resultValue.Length > 16 && !resultValue.Contains(".") && !resultValue.Contains("-"))
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

        private static string Rounding2(string resultValue, int num)
        {
            string value1 = resultValue.Substring(0, num);
            string value2 = resultValue.Substring(num, 1);
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
