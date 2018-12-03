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
        }

        public string ClearResultValue()
        {
            return "";
        }

        public string ClearExpression()
        {
            return "";
        }
    }
}
