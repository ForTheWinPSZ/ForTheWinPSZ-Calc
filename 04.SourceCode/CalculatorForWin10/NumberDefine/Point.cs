using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public class Point
    {
        private string resultValue;
        private bool canNumberDef;

        public Point(string resultValue,bool canNumberDef)
        {
            this.resultValue = resultValue;
            this.canNumberDef = canNumberDef;
            InputNum();
        }

        public void InputNum()
        {
            if (!canNumberDef)
            {
                resultValue = "";
            }
            if (resultValue == "")
            {
                resultValue = "0.";
            }
            if (!resultValue.Contains("."))
            {
                resultValue += ".";
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
