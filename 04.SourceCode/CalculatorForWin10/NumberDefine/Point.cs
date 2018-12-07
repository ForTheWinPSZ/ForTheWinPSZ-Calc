using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public class Point
    {
        private string resultValue;
        private bool canNumberDef;
        private string expressionValue;
        public Point(string resultValue,bool canNumberDef, string expressionValue)
        {
            this.resultValue = resultValue;
            this.canNumberDef = canNumberDef;
            this.expressionValue = expressionValue;
            InputNum();
        }

        public void InputNum()
        {
            if (!canNumberDef)
            {
                if (!expressionValue.EndsWith(" ") && expressionValue != "")
                {
                    string[] arr = expressionValue.Split(new char[] { ' ' });
                    expressionValue = expressionValue.Replace(arr[arr.Length - 1], "");
                }
                resultValue = "";
            }
            if (resultValue == "")
            {
                resultValue = "0.";
            }
            if (!resultValue.Contains("."))
            {
                resultValue += ".";
            }
        }
        public string ReturnResultValue()
        {
            return resultValue;
        }

        public bool ReturnCanNumberDef()
        {
            return true;
        }
        public string ReturnExpressionValue()
        {
            return expressionValue;
        }
    }
}
