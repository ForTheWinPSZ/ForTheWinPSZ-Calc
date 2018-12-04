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
        private string preUnaryResult;
        private string displayText = "";
        private string preResult;

        public Reciprocal(string expressionValue, string resultValue,string preUnaryResult, string preResult)
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

        public void ChangeExpression()
        {
            if (expressionValue == "" || IsBinary() == true)
            {
                Debug.WriteLine("结尾不是单目");
                expressionValue += "1/(" + ToDouble(displayText) + ")";
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
            preUnaryResult = Calculate(displayText);
            resultValue = "";
        }

        public string Calculate(string param)
        {
            if (param == "0")
            {
                return "除数不能为零";
            }
            else
            {
                //倒数
                return (1 / ToDouble(param)).ToString().ToLower();
            }
        }
        //最后一部分是否是双目运算
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

        public string ReturnPreUnaryResult()
        {
            return preUnaryResult;
        }
    }
}
