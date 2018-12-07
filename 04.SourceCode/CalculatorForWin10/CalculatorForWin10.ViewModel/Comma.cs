using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForWin10.ViewModel
{
    static class Comma
    {
        public static string AddComma(string resultValue)
        {
            string integer; //输出框逗号显示部分
            #region 限制输出框最大容纳位数
            //负数小数，输出框最大容纳19位
            if (resultValue.Contains("-") && resultValue.Contains(".") && resultValue.Length >= 19)
            {
                resultValue = resultValue.Substring(0, 19);
            }
            //正数小数，输出框最大容纳18位
            else if (!resultValue.Contains("-") && resultValue.Contains(".") && resultValue.Length >= 18)
            {
                resultValue = resultValue.Substring(0, 18);
            }
            //负整数，输出框最大容纳17位
            else if (resultValue.Contains("-") && !resultValue.Contains(".") && resultValue.Length >= 17)
            {
                resultValue = resultValue.Substring(0, 17);
            }
            //正整数，输出框最大容纳16位
            else if (!resultValue.Contains("-") && !resultValue.Contains(".") && resultValue.Length >= 16)
            {
                resultValue = resultValue.Substring(0, 16);
            }
            #endregion

            if (resultValue.Contains("."))  //处理小数
            {
                integer = resultValue.Substring(0, resultValue.IndexOf("."));
                CommaIndex(ref integer);
                return integer + resultValue.Substring(resultValue.IndexOf("."));
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
