using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public class Zero: Number
    {
        public Zero(string content, string resultValue,bool canNumberDef, string expressionValue):base(content, resultValue, canNumberDef, expressionValue)
        {
        }

        public override void InputNum()
        {
            if (!CanNumberDef)
            {
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
            if ((ResultValue.Contains("-") && ResultValue.Contains(".") && ResultValue.Length >= 19) ||
               (!ResultValue.Contains("-") && ResultValue.Contains(".") && ResultValue.Length >= 18) ||
               (ResultValue.Contains("-") && !ResultValue.Contains(".") && ResultValue.Length >= 17) ||
                    (!ResultValue.Contains("-") && !ResultValue.Contains(".") && ResultValue.Length >= 16))
                return;
            if (!("".Equals(ResultValue) || "0".Equals(ResultValue)))
            {
                ResultValue += Content;

            }
        }
    }
}
