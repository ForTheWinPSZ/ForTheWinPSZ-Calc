using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NumberDefine
{
    public class OneToNine
    {
        private string resultValue;
        private string content;
        public OneToNine(string content, string resultValue) {
            this.content = content;
            this.resultValue = resultValue;
            InputNum();
            AddComma();
        }

        private void InputNum()
        {
            if ("".Equals(resultValue)||"0".Equals(resultValue))
            {
                resultValue = content;
            }
            else
            {
                resultValue += content;
            }
            
        }

        //为整数部分添加逗号,在点击之后发生，所以方法需在inputNum之后
        private void AddComma()
        {
            string integer;
            //判断是否有小数点，只取整数部分
            if (resultValue.Contains("."))
            {
                integer = resultValue.Substring(0, resultValue.IndexOf("."));
                CommaIndex(ref integer);
                resultValue = integer+resultValue.Substring(resultValue.IndexOf("."));
            }
            else
            {
                integer = resultValue;
                CommaIndex(ref integer);
                resultValue = integer;
            }
            
        }
        //AddComma方法的子部分，负责计算
        private void CommaIndex(ref string integer)
        {
            //整数部分3个以下不需要加逗号
            if (integer.Length <= 3)
                return;

            char[] strs = integer.ToCharArray();
            List<char> list = new List<char>();
            for (int i = 0; i < strs.Length; i++)
            {
                if (i == strs.Length % 3)
                    list.Add(',');
                list.Add(strs[i]);
            }
            integer = string.Join("",list.ToArray());
        }

        public string ReturnResultValue() {
            return resultValue;
        }
    }
}
