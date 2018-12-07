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
    {        public Percent(string ExpressionValue, string ResultValue, string PreResult) : base(ExpressionValue, ResultValue, PreResult)        {        }        public override void ChangeExpression()        {            if (ExpressionValue == "" || ExpressionValue.EndsWith(" "))            {                ExpressionValue += ResultValue;            }            else            {                string UnaryExpression = GetUnaryExpression().Trim();                string partExpression = ExpressionValue.Substring(0, binaryIndex);                ExpressionValue = partExpression + Calculate(displayText);            }        }        public override void ChangeResultValue()        {            ResultValue = Calculate(displayText = ResultValue == "" ? PreResult : ResultValue);        }        public string Calculate(string param)        {
            if (PreResult == "")
                PreResult = "0";
            return ((ToDouble(PreResult) * ToDouble(param) / 100)).ToString().ToLower();        }

        
    }
}
