using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class C : IClear
    {
        private string resultValue;
        private string expressionValue;

        public C(string resultValue, string expressionValue)
        {
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
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
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }

        public string ReturnExpressionValue()
        {
            return expressionValue;
        }
    }
}
