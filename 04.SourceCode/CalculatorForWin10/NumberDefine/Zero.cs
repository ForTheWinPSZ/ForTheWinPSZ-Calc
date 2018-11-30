using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    class Zero
    {
        private string resultValue;
        private string expressionValue;

        public Zero(string resultValue, string expressionValue)
        {
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
        }

        private void InputNum()
        {
            if (!(Double.Parse(resultValue) == 0)) {
                resultValue += "0";

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
