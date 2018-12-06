using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;using static System.Convert;namespace Arithmetic.UnaryOperation{    public class Reverse : IUnary    {        private string expressionValue;        private string resultValue;        private int binaryIndex;        private string preResult;        private string displayText = "";        private bool canNumberDef;        public Reverse(string expressionValue, string resultValue, string preResult,bool canNumberDef)        {            this.expressionValue = expressionValue;            this.resultValue = resultValue;            this.preResult = preResult;
            this.canNumberDef = canNumberDef;
            ChangeResultValue();
            ChangeExpression();

        }        

        public void ChangeExpression()        {


            if ((expressionValue == "" || expressionValue.EndsWith(" ")) && (canNumberDef == false && preResult != ""))
            {
                Debug.WriteLine("结尾不是单目");
                expressionValue += "negate(" + ToDouble(displayText) + ")";
            }
            else if (expressionValue.EndsWith(")"))
            {
                Debug.WriteLine("结尾是单目");
                string UnaryExpression = GetUnaryExpression().Trim();
                string partExpression = expressionValue.Substring(0, binaryIndex);
                expressionValue = partExpression + "negate(" + UnaryExpression + ")";
            }



        }        public void ChangeResultValue()        {            resultValue = Tool1.Calculate("reverse", displayText = resultValue == "" ? preResult : resultValue);        }        public string GetUnaryExpression()        {            binaryIndex = expressionValue.LastIndexOf(" ") + 1;            return expressionValue.Substring(binaryIndex);        }        public string ReturnExpressionValue()        {            return expressionValue;        }


        public string ReturnResultValue()        {            return resultValue;        }        public bool ReturnCanNumberDef()
        {
            return canNumberDef;
        }    }}