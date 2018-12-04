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
        private string preUnaryResult;

        public C(string resultValue, string expressionValue,string preResult,string preUnaryResult)
        {
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
            this.preResult = preResult;
            this.preUnaryResult = preUnaryResult;
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
            preUnaryResult = "";
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

        public string ReturnPreUnaryResult()
        {
            return preUnaryResult;
        }
    }
}
