using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public class Zero
    {
        private string resultValue;
        private bool canNumberDef;
        private string expressionValue;
        public Zero(string resultValue,bool canNumberDef, string expressionValue)
        {
            this.resultValue = resultValue;
            this.canNumberDef = canNumberDef;
            this.expressionValue = expressionValue;
            InputNum();
        }

        private void InputNum()
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
                resultValue = "0";
            }
            if ((resultValue.Contains("-") && resultValue.Contains(".") && resultValue.Length >= 19) ||
               (!resultValue.Contains("-") && resultValue.Contains(".") && resultValue.Length >= 18) ||
               (resultValue.Contains("-") && !resultValue.Contains(".") && resultValue.Length >= 17) ||
                    (!resultValue.Contains("-") && !resultValue.Contains(".") && resultValue.Length >= 16))
                return;
            if (!("".Equals(resultValue) || "0".Equals(resultValue)))
            {
                resultValue += "0";

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
