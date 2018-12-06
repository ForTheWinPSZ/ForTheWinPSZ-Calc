using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;using static System.Convert;namespace Arithmetic.UnaryOperation{    public class Reverse : IUnary    {        private string expressionValue;        private string resultValue;        private int binaryIndex;        private string preResult;        private string displayText = "";        public Reverse(string expressionValue, string resultValue, string preResult)        {            this.expressionValue = expressionValue;            this.resultValue = resultValue;            this.preResult = preResult;
            ChangeResultValue();
            ChangeExpression();

        }        public string Calculate(string param)        {            return (ToDouble(param) * -1).ToString().ToLower();        }


        public void ChangeExpression()        {


            if (expressionValue.EndsWith(" "))
            {
                Debug.WriteLine("结尾不是单目");
                expressionValue += "negate(" + ToDouble(displayText) + ")";
            }
            else if (expressionValue.EndsWith(")"))
            {
                Debug.WriteLine("结尾是单目");
                string UnaryExpression = GetUnaryExpression().Trim();
                string partExpression = expressionValue.Substring(0, binaryIndex + 1);
                expressionValue = partExpression + " negate(" + UnaryExpression + ")";
            }



        }        public void ChangeResultValue()        {            resultValue = Calculate(displayText = resultValue == "" ? preResult : resultValue);        }        public string GetUnaryExpression()        {            char[] binary = { '+', '-', '×', '÷' };            binaryIndex = expressionValue.LastIndexOfAny(binary);            return expressionValue.Substring(binaryIndex + 1);        }        public string ReturnExpressionValue()        {            return expressionValue;        }


        public string ReturnResultValue()        {            return resultValue;        }    }}