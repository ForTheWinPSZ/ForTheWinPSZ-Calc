using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NumberDefine
{
    public class OneToNine
    {
        private string resultValue;
        private string content;
        private bool canNumberDef;
        private string expressionValue;
        public OneToNine(string content, string resultValue,bool canNumberDef,string expressionValue) {
            this.content = content;
            this.resultValue = resultValue;
            this.canNumberDef = canNumberDef;
            this.expressionValue = expressionValue;
            InputNum();
        }

        private void InputNum()
        {
            if (!canNumberDef)
            {
                if (!expressionValue.EndsWith(" ") && expressionValue!="")
                {
                    string[] arr = expressionValue.Split(new char[] { ' ' });
                    expressionValue=expressionValue.Replace(arr[arr.Length - 1], "");
                }
                resultValue = "";
            }
            if ("0".Equals(resultValue))
                resultValue = content;
            else
            {
                resultValue += content;
            }
        }
        
        public string ReturnResultValue() {
            return resultValue;
        }
        public string ReturnExpressionValue()
        {
            return expressionValue;
        }
        public bool ReturnCanNumberDef()
        {
            return true;
        }
    }
}
