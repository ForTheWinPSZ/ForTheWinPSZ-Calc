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
       
        public Point(string resultValue)
        {
            this.resultValue = resultValue;
            InputNum();
        }

        public void InputNum()
        {
            if (!resultValue.Contains("."))
            {
                resultValue += ".";
            }
        }
        public string ReturnResultValue()
        {
            return resultValue;
        }

    }
}
