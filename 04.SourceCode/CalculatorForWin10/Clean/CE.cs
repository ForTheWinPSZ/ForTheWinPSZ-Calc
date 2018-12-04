using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class CE : IClear
    {
        private string resultValue;
        private string expressionValue;
        private string preResult;

        public CE(string resultValue,string expressionValue,string preResult)
        {
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
            this.preResult = preResult;
            if (preResult == "无效输入" || preResult == "除数不能为零")
            {
                expressionValue = "";
                preResult = "";
            }
            ClearResultValue();
        }

        public void ClearResultValue()
        {
            resultValue = "0";
        }

        public string ReturnExpressionValue()
        {
            return resultValue;
        }

        public string ReturnPreResult()
        {
            return preResult;
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }
    }
}
