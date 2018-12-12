using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public class Point:Number
    {
        public Point(string content,string resultValue, bool canNumberDef, string expressionValue) : base(content,resultValue, canNumberDef, expressionValue)
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
                ResultValue = "0.";
            }
            if (!ResultValue.Contains("."))
            {
                ResultValue += Content;
            }
        }
    }
}
