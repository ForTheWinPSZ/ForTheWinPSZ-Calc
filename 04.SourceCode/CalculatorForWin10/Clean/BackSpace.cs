using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class BackSpace
    {
        private string resultValue;
        private string expressionValue;
        private string preResult;

        public BackSpace(string resultValue, string expressionValue, string preResult)
        {
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
            this.preResult = preResult;
            if (preResult == "无效输入" || preResult == "除数不能为零")
            {
                expressionValue = "";
                preResult = "";
                resultValue = "0";
            }
            else
            {
                BackSp();
            }
        }

        public void BackSp()
        {
            if (resultValue.Length > 1)
            {
                resultValue = resultValue.Remove(resultValue.Length - 1);
            }
            else if (resultValue.Length == 1)
            {
                resultValue = "0";
            }
            else
            {
                return;
            }
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }

        public string ReturnPreResult()
        {
            return preResult;
        }

        public string ReturnExpressionValue()
        {
            return resultValue;
        }
    }
}
