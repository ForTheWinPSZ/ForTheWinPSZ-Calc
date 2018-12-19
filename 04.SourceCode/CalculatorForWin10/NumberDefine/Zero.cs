using Arithmetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public class Zero: Number
    {
        public Zero(string content, string resultValue,bool canNumberDef, string expressionValue, string preResult, List<History> history, string lparm) : base(content, resultValue, canNumberDef, expressionValue, preResult, history, lparm)
        {
        }

        public override void InputNum()
        {
            if (!CanNumberDef)
            {               
                if (ResultValue != "" && ExpressionValue != "" && ExpressionValue.Split(new char[] { ' ' }).Length == 1)
                {
                    Lparm = ResultValue;
                    historyString = ExpressionValue;
                    AddHistory();
                    IsUnary = true;
                }
                else
                {
                    IsUnary = false;
                }
                if (!ExpressionValue.EndsWith(" ") && ExpressionValue != "")
                {
                    string[] arr = ExpressionValue.Split(new char[] { ' ' });
                    ExpressionValue = ExpressionValue.Replace(arr[arr.Length - 1], "");
                }
                ResultValue = "";
            }
            if (ResultValue == "")
            {
                ResultValue = Content;
            }
            
            if (!("".Equals(ResultValue) || "0".Equals(ResultValue)))
            {
                ResultValue += Content;

            }
        }
    }
}
