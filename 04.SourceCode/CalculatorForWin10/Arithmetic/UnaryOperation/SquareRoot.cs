using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Convert;

namespace Arithmetic.UnaryOperation
{
    public class SquareRoot : IUnary
    {
        private string expressionValue;
        private string resultValue;
        private int binaryIndex;
        private string preResult;

        public SquareRoot(string expressionValue, string resultValue,string preResult)
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
            string displayText = "";
            if (resultValue == "" && preResult == "")
            {
                displayText = expressionValue.Remove(expressionValue.Length - 1).Trim();
            }
            else
            {
                displayText = resultValue == "" ? preResult : resultValue;
            }
            if (expressionValue == "" || IsUnary() == false)
            {
                Debug.WriteLine("结尾不是单目");
                expressionValue += " √(" + displayText + ")";
            }
            else
            {
                Debug.WriteLine("结尾是单目");
                string UnaryExpression = GetUnaryExpression().Trim();
                string partExpression = expressionValue.Substring(0, binaryIndex + 1);
                expressionValue = partExpression + "√(" + UnaryExpression + ")";
            }
        }

        public void ChangeResultValue()
        {
            preResult = resultValue == "" ? Calculate(preResult) : Calculate(resultValue);
            resultValue = "";
            
        }

        public string Calculate(string param)
        {
            if (param.StartsWith("-"))
            {
                return "无效输入";
            }
            else
            {
                //开方
                return Math.Sqrt(ToDouble(param)).ToString().ToLower();
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

        public string ReturnPreResult()
        {
            return preResult;
        }
    }
}
