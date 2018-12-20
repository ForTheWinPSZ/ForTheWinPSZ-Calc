using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Convert;

namespace Arithmetic
{
    public static class HistoryDisplayTool
    {
        //为历史记录的结果值添加逗号
        public static string AddComma(string resultValue)
        {
            char[] strs = { '不', '无', '未', '溢' };
            //科学记数法暂时不作取舍
            if (resultValue.Contains("e") || resultValue.IndexOfAny(strs) != -1)
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
                    resultValue = resultValue.Substring(1, resultValue.Length - 1);
                    integer = resultValue;
                    CommaIndex(ref integer);
                    return "-" + integer;
                }
                else if (resultValue.IndexOfAny(strs) != -1)
                    return resultValue;
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
        #region 限制输出框最大容纳位数,这里仅供存入表达式与历史记录使用
        public static string MaxContain(string resultValue)
        {
            char[] strs = { '不', '无', '未', '溢' };
            if (resultValue == null || resultValue == "" || resultValue.IndexOfAny(strs) != -1)
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

        //显示时对数据进行四舍五入
        public static string Rounding2(string resultValue, int num)
        {
            string value1 = resultValue.Substring(0, num);
            string value2 = "";
            if (resultValue.Substring(num, 1).Equals("."))
                value2 = resultValue.Substring(num + 1, resultValue.Length - num - 1);
            else
                value2 = resultValue.Substring(num, resultValue.Length - num);
            value2 = value2.Insert(1, ".");
            if (Math.Round(ToDouble(value2), 0) >= 5)
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
