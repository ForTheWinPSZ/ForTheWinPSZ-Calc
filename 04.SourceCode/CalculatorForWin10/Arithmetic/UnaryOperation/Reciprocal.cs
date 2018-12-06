using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;using static System.Convert;namespace Arithmetic.UnaryOperation{    public class Reciprocal : IUnary    {        private string expressionValue;        private string resultValue;        private int binaryIndex;        private string displayText = "";        private string preResult;        public Reciprocal(string expressionValue, string resultValue, string preResult)        {            this.expressionValue = expressionValue;            this.resultValue = resultValue;            this.preResult = preResult;

            ChangeResultValue();

            ChangeExpression();

        }        public void ChangeExpression()        {            if (expressionValue == "" || expressionValue.EndsWith(" "))            {                Debug.WriteLine("结尾不是单目");                expressionValue += "1/(" + ToDouble(displayText) + ")";            }            else            {                Debug.WriteLine("结尾是单目");                string UnaryExpression = GetUnaryExpression().Trim();                string partExpression = expressionValue.Substring(0, binaryIndex);                expressionValue = partExpression + "1/(" + UnaryExpression + ")";            }        }        public void ChangeResultValue()        {            resultValue = Calculate(displayText = resultValue == "" ? preResult : resultValue);        }        public string Calculate(string param)        {            if (param == "0")            {                return "除数不能为零";            }            else            {
                //倒数
                return (1 / ToDouble(param)).ToString().ToLower();            }        }
        //最后一部分是否是双目运算


        public string ReturnExpressionValue()        {            return expressionValue;        }        public string ReturnResultValue()        {            return resultValue;        }        public string GetUnaryExpression()        {            binaryIndex = expressionValue.LastIndexOf(" ") + 1;            return expressionValue.Substring(binaryIndex);        }    }}