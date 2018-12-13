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
    {        public Percent(string ExpressionValue, string ResultValue, string PreResult) : base(ExpressionValue, ResultValue, PreResult)        {            Debug.WriteLine("1123");        }        public override void ChangeExpression()        {            if (ExpressionValue == "" || ExpressionValue.EndsWith(" "))            {                ExpressionValue += ResultValue;            }            else            {                string UnaryExpression = GetUnaryExpression().Trim();                string partExpression = ExpressionValue.Substring(0, binaryIndex);                ExpressionValue = partExpression + Calculate(displayText);            }        }        public override void ChangeResultValue()        {                        string[] strs = ExpressionValue.Split(' ');            char[] binary = {  '×', '÷' };
            int index = ExpressionValue.LastIndexOfAny(binary);
            if(index!=-1)
            {
                if(strs[strs.Length-1].LastIndexOfAny(binary)!=-1|| strs[strs.Length - 2].LastIndexOfAny(binary) != -1)
                    ResultValue = displayText = ResultValue == "" ? (ToDecimal(PreResult) / 100).ToString() : (ToDecimal(ResultValue) / 100).ToString();
                else
                    ResultValue = Calculate(displayText = ResultValue == "" ? PreResult : ResultValue);
            }
            else                ResultValue = Calculate(displayText = ResultValue == "" ? PreResult : ResultValue);        }        public string Calculate(string param)        {
            if (PreResult == "")
                PreResult = "0";
            return ((ToDecimal(PreResult) * ToDecimal(param) / 100)).ToString();        }

        
    }
}
