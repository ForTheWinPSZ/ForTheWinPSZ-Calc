using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using System.Diagnostics;

namespace Arithmetic.UnaryOperation
{
    public class Square : IUnary
    {
        private string expressionValue;
        private string resultValue;
        private int binaryIndex;
        private string preResult;

        public Square(string expressionValue, string resultValue,string preResult)
        {
            this.expressionValue = expressionValue;
            this.resultValue = resultValue;
            this.preResult = preResult;
            if (preResult != "无效输入" && preResult != "除数不能为零")
            {
                //改变表达式栏
                ChangeExpression();
                //改变结果栏
                ChangeResultValue();
            }
        }
        
        public void ChangeExpression()
        {
            if (expressionValue == "" || IsUnary() == false)
            {
                Debug.WriteLine("结尾不是单目");
                expressionValue += " sqr(" + preResult + ")";
            }
            else
            {
                Debug.WriteLine("结尾是单目");
                string UnaryExpression = GetUnaryExpression().Trim();
                string partExpression = expressionValue.Substring(0, binaryIndex + 1);
                expressionValue = partExpression + "sqr(" + UnaryExpression + ")";
            }
        }

        public void ChangeResultValue()
        {
            preResult = resultValue == "" ? Calculate(preResult) : Calculate(resultValue);
            resultValue = "";
        }

        public string Calculate(string param)
        {
            //平方
            return (ToDouble(param) * ToDouble(param)).ToString().ToLower();
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

        public string ReturnPreResult()
        {
            return preResult;
        }
    }
}
