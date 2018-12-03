using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class C : IClear
    {
        private string resultValue;
        private string expressionValue;
        private string preResult;

        public C(string resultValue, string expressionValue,string preResult)
        {
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
            this.preResult = preResult;
            ClearExpression();
            ClearResultValue();
        }

        public void ClearResultValue()
        {
            resultValue = "0";
        }

        public void ClearExpression()
        {
            expressionValue = "";
            preResult = "";
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }

        public string ReturnExpressionValue()
        {
            return expressionValue;
        }

        public string ReturnPreResult()
        {
            return preResult;
        }
    }
}
