using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    class Point
    {
        private string resultValue;
        private string expressionValue;

        public Point(string resultValue, string expressionValue)
        {
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
        }

        public void InputNum()
        {
            if (!resultValue.Contains("."))
            {
                resultValue += ".";
            }
        }
        public string returnResult()
        {
            return resultValue;
        }
        public string returnExpressionValue()
        {
            return expressionValue;
        }

    }
}
