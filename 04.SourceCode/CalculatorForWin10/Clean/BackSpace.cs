using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class BackSpace
    {
        private string resultValue;

        public BackSpace(string resultValue)
        {
            this.resultValue = resultValue;
            BackSp();
        }

        public void BackSp()
        {
            if (resultValue.Length > 1)
            {
                resultValue = resultValue.Remove(resultValue.Length - 1);
            }
            else
            {
                resultValue = "0";
            }
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }
    }
}
