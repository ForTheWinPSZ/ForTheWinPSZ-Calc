using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Convert;

namespace Arithmetic.UnaryOperation
{
    public class Reciprocal : IUnary
    {
        private string expressionValue;
        private string resultValue;
        private int binaryIndex;

        public Reciprocal(string expressionValue, string resultValue)
        {
            this.expressionValue = expressionValue;
            this.resultValue = resultValue;
            if (resultValue != "无效输入" && resultValue != "除数不能为零")
            {
                //改变表达式栏
                ChangeExpression();
                //计算
                Calculate();
                //改变结果栏
                ChangeResultValue();
            }
        }

        public void ChangeExpression()
        {
            if (expressionValue == "" || IsUnary() == false)
            {
                Debug.WriteLine("结尾不是单目");
                expressionValue += " 1/(" + resultValue + ")";
            }
            else
            {
                Debug.WriteLine("结尾是单目");
                string UnaryExpression = GetUnaryExpression().Trim();
                string partExpression = expressionValue.Substring(0, binaryIndex + 1);
                expressionValue = partExpression + "1/(" + UnaryExpression + ")";
            }
        }

        public void ChangeResultValue()
        {
            resultValue = Calculate();
        }

        public string Calculate()
        {
            if (resultValue == "0")
            {
                return "除数不能为零";
            }
            else
            {
                //倒数
                return (1 / ToDouble(resultValue)).ToString().ToLower();
            }
        }
        //最后一部分是否是双目运算
        public bool IsBinary()
        {
            if (expressionValue.EndsWith(")"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //最后一部分是否是单目运算
        public bool IsUnary()
        {
            if (expressionValue.EndsWith(")"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ReturnExpressionValue()
        {
            return expressionValue;
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }

        public string GetUnaryExpression()
        {
            char[] binary = { '+', '-', '×', '÷' };
            binaryIndex = expressionValue.LastIndexOfAny(binary);
            return expressionValue.Substring(binaryIndex + 1);
        }
    }
}
