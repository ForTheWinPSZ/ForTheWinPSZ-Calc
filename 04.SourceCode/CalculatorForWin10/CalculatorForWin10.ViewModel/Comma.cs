using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForWin10.ViewModel
{
    static class Comma
    {
        //为整数部分添加逗号
        public static string AddComma(string resultValue)
        {
            string integer;
            if (resultValue.Contains("-") && resultValue.Contains(".") && resultValue.Length >= 19)
            {
                resultValue=resultValue.Substring(0,19);
            }
            else if (!resultValue.Contains("-") && resultValue.Contains(".") && resultValue.Length >= 18)
            {
                resultValue = resultValue.Substring(0, 18);
            }
            else if (resultValue.Contains("-") && !resultValue.Contains(".") && resultValue.Length >= 17)
            {
                resultValue = resultValue.Substring(0, 17);
            }
            else if (!resultValue.Contains("-") && !resultValue.Contains(".") && resultValue.Length >= 16)
            {
                resultValue = resultValue.Substring(0, 16);
            }

                if (resultValue.Contains("."))
                {
                    //判断是否有小数点，只取整数部分
                    integer = resultValue.Substring(0, resultValue.IndexOf("."));
                    CommaIndex(ref integer);
                    return integer + resultValue.Substring(resultValue.IndexOf("."));
                }
                else
                {
                    integer = resultValue;
                    CommaIndex(ref integer);
                    return integer;
                }
            
            
            

        }
        //AddComma方法的子部分，负责计算
        private static void CommaIndex(ref string integer)
        {
            //整数部分3个以下不需要加逗号
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


    }
}
