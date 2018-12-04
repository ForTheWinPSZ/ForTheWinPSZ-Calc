using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Convert;

namespace Arithmetic.UnaryOperation
{
    public class Reverse : IUnary
    {
        private string expressionValue;
        private string resultValue;
        private int binaryIndex;
        private string preUnaryResult;
        private string displayText = "";
        private string preResult;

        public Reverse(string expressionValue, string resultValue, string preUnaryResult, string preResult)
        {
            this.expressionValue = expressionValue;
            this.resultValue = resultValue;
            this.preUnaryResult = preUnaryResult;
            this.preResult = preResult;
            if (preUnaryResult != "无效输入" && preUnaryResult != "除数不能为零")
            {
                //改变结果栏
                ChangeResultValue();
                //改变表达式栏
                ChangeExpression();
            }
        }

        public string Calculate(string param)
        {
            return (ToDouble(param) * -1).ToString().ToLower();
        }

        public void ChangeExpression()
        {
            if (resultValue == "")
            {
                preUnaryResult = Calculate(displayText);
                resultValue = "";
                if (expressionValue == "" || IsBinary() == true)
                {
                    Debug.WriteLine("结尾不是单目");
                    expressionValue += "negate(" + ToDouble(displayText) + ")";
                }
                else
                {
                    Debug.WriteLine("结尾是单目");
                    string UnaryExpression = GetUnaryExpression().Trim();
                    string partExpression = expressionValue.Substring(0, binaryIndex + 1);
                    expressionValue = partExpression + "negate(" + UnaryExpression + ")";
                }
            }
            else
            {
                resultValue = Calculate(displayText);
            }
        }

        public void ChangeResultValue()
        {
            if (resultValue == "")
            {
                if (preResult == "" && preUnaryResult == "")
                {
                    displayText = expressionValue.Remove(expressionValue.Length - 2).Trim();
                }
                else
                {
                    if (IsBinary())
                    {
                        displayText = preResult;
                    }
                    else
                    {
                        displayText = preUnaryResult;
                    }
                }
            }
            else
            {
                displayText = resultValue;
            }
        }

        public string GetUnaryExpression()
        {
            char[] binary = { '+', '-', '×', '÷' };
            binaryIndex = expressionValue.LastIndexOfAny(binary);
            return expressionValue.Substring(binaryIndex + 1);
        }

        public bool IsBinary()
        {
            if (expressionValue.EndsWith(" "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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

        public string ReturnPreUnaryResult()
        {
            return preUnaryResult;
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }
    }
}
