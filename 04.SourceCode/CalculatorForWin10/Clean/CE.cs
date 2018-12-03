using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class CE : IClear
    {
        private string resultValue;

        public CE(string resultValue)
        {
            this.resultValue = resultValue;
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

        public string ReturnResultValue()
        {
            return resultValue;
        }
    }
}
