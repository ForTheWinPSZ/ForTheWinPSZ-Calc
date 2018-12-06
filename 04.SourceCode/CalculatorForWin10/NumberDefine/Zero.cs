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
        private bool canNumberDef;

        public Zero(string resultValue,bool canNumberDef)
        {
            this.resultValue = resultValue;
            this.canNumberDef = canNumberDef;
            InputNum();
        }

        private void InputNum()
        {
            if (!canNumberDef)
            {
                resultValue = "";
            }
            if (resultValue == "")
            {
                resultValue = "0";
            }
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

        public bool ReturnCanNumberDef()
        {
            return true;
        }
    }
}
