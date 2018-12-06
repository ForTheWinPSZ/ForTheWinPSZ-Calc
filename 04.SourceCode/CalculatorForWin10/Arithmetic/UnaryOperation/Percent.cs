using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using System.Diagnostics;

namespace Arithmetic.UnaryOperation
{
    public class Percent : IUnary
    {
        private string expressionValue;        private string resultValue;        private int binaryIndex;        private string displayText = "";        private string preResult;        public Percent(string expressionValue, string resultValue, string preResult)        {            this.expressionValue = expressionValue;            this.resultValue = resultValue;            this.preResult = preResult;            ChangeResultValue();            ChangeExpression();        }        public void ChangeExpression()        {            if (expressionValue == "" || expressionValue.EndsWith(" "))            {                Debug.WriteLine("结尾是双目");                expressionValue += resultValue;            }            else            {                Debug.WriteLine("结尾是单目");                string UnaryExpression = GetUnaryExpression().Trim();                string partExpression = expressionValue.Substring(0, binaryIndex);                expressionValue = partExpression + Calculate(displayText);            }        }        public void ChangeResultValue()        {            resultValue = Calculate(displayText = resultValue == "" ? preResult : resultValue);        }        public string Calculate(string param)        {
            if (preResult=="")
            {
                preResult = "0";
            }
            return ((ToDouble(preResult) * ToDouble(param)/100)).ToString().ToLower();        }        public string ReturnExpressionValue()        {            return expressionValue;        }        public string ReturnResultValue()        {            return resultValue;        }        public string GetUnaryExpression()        {            binaryIndex = expressionValue.LastIndexOf(" ") + 1;            return expressionValue.Substring(binaryIndex);        }
    }
}
