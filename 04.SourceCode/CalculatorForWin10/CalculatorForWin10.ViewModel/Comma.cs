using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace CalculatorForWin10.ViewModel
{
    static class Comma
    {
        public static string MaxContain(string resultValue,bool isNumDef)
        {
            if (isNumDef||resultValue == ""||resultValue.Contains("不") || resultValue.Contains("无") || resultValue.Contains("未"))
                return resultValue;
            //科学记数法暂时不作取舍
            if (resultValue.Contains("e") || resultValue.Contains("E"))
                return resultValue;
            //去掉小数后面多余的0
            if (!isNumDef && resultValue.Contains("."))
                resultValue = resultValue.TrimEnd('0');
            #region 限制输出框最大容纳位数
            //判断是否为0.
            int index;
            if (ToDouble(resultValue) < 1 && ToDouble(resultValue) > -1)
                index = 1;
            else
                index = 0;           
            //有点有负号
            if (resultValue.Contains(".") && resultValue.Contains("-") && resultValue.Length > index + 18)
            {                
                resultValue = Rounding2(resultValue, index + 18);
                //resultValue = resultValue.Substring(0, index + 17) + Rounding(resultValue.Substring(index + 17, 1), resultValue.Substring(index + 18, 1));
            }
            //有点无负号
            else if (resultValue.Length > index + 17 && resultValue.Contains(".") && !resultValue.Contains("-"))
            {
                Debug.WriteLine("Comma resultValue:"+resultValue);
                resultValue = Rounding2(resultValue,index+17);
                //resultValue = resultValue.Substring(0, index + 16) + Rounding(resultValue.Substring(index + 16, 1), resultValue.Substring(index + 17, 1));                
            }
            //无点有负号
            else if (resultValue.Length > 17 && !resultValue.Contains(".") && resultValue.Contains("-"))
            {
                resultValue = Rounding2(resultValue,17);
                //resultValue = resultValue.Substring(0, 16) + Rounding(resultValue.Substring(16, 1), resultValue.Substring(17, 1));
            }
            //无点无负号
            else if (resultValue.Length > 16 && !resultValue.Contains(".") && !resultValue.Contains("-"))
            {
                resultValue = Rounding2(resultValue, 16);
                //resultValue = resultValue.Substring(0, 15) + Rounding(resultValue.Substring(15, 1), resultValue.Substring(16, 1));
            }

            if (!isNumDef)
            {
                //去掉小数后面多余的0和点
                if (resultValue.Contains("."))
                    resultValue = resultValue.TrimEnd('0');
                //去掉尾数的点
                if(resultValue.EndsWith("."))
                    resultValue = resultValue.TrimEnd('.');
            }

            
            
            #endregion
            return resultValue;
        }

        private static string Rounding2(string resultValue, int num)
        {
            Debug.WriteLine("resultValue:"+resultValue);
            Debug.WriteLine("num:"+num);
            string value1 = resultValue.Substring(0, num);
            string value2 = resultValue.Substring(num, 1);
            if (ToDouble(value2) >= 5)
            {
                char[] arr = value1.ToCharArray();
                for(int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] == '.')
                        continue;
                    if (arr[i] != '9')
                    {
                        int a= ToInt32(arr[i]) - 47;
                        arr[i] = char.Parse(a.ToString());
                        break;
                    }
                    else
                    {
                        arr[i] = '0';                         
                    }
                        
                }
                return new string(arr);
            }
            else
            {
                return value1;
            }
        }

        public static string AddComma(string resultValue)
        {
            //科学记数法暂时不作取舍
            if (resultValue.Contains("e") || resultValue.Contains("E"))
                return resultValue;
            string integer; //输出框逗号显示部分
            if (resultValue.Contains("."))  //处理小数(正小数、负小数)
            {
                if (resultValue.Contains("-"))
                {
                    resultValue = resultValue.Substring(1, resultValue.Length - 1);
                    integer = resultValue.Substring(0, resultValue.IndexOf("."));
                    CommaIndex(ref integer);
                    return "-" + integer + resultValue.Substring(resultValue.IndexOf("."));
                }
                else
                {                    
                    integer = resultValue.Substring(0, resultValue.IndexOf("."));
                    CommaIndex(ref integer);                  
                    return integer + resultValue.Substring(resultValue.IndexOf("."));
                }           
            }
            else                         //处理整数(正整数、负整数)
            {
                if (resultValue.Contains("-"))
                {
                    resultValue = resultValue.Substring(1, resultValue.Length-1);
                    integer = resultValue;
                    CommaIndex(ref integer);
                    return "-" + integer;
                }
                else if (resultValue == "除数不能为零" || resultValue == "无效输入" || resultValue == "结果未定义")
                {
                    return resultValue;
                }
                else
                {
                    integer = resultValue;
                    CommaIndex(ref integer);
                    return integer;
                }
            }
        }
        #region AddComma方法的子部分，负责计算
        private static void CommaIndex(ref string integer)
        {
            // 3位数以下不要“逗号”
            if (integer.Length <= 3)
                return;

            char[] strs = integer.ToCharArray();
            List<char> list = new List<char>();
            int len = strs.Length;
            for (int i = 0; i < len; i++)
            {
                list.Add(strs[i]);
            }
            int index = len / 3 - 1;
            for (int i = 0; i <= index; i++)
            {
                if ((len % 3 == 0) && i == 0)
                    continue;
                if ((len % 3 == 0) && i != 0)
                {
                    list.Insert(i * 3 + i - 1, ',');
                    continue;
                }
                list.Insert(len % 3 + i * 3 + i, ',');
            }
            integer = string.Join("", list.ToArray());
        }
        #endregion

        
    }
}
