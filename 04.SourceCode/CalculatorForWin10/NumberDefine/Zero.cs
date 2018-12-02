using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public class Zero
    {
        private string resultValue;

        public Zero(string resultValue)
        {
            this.resultValue = resultValue;
            InputNum();
        }

        private void InputNum()
        {
            if (resultValue.Length >= 16)
                return;
            if (!("".Equals(resultValue) || "0".Equals(resultValue)))
            {
                resultValue += "0";

            }
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }
    }
}
