using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NumberDefine
{
    public class OneToNine
    {
        private string resultValue;
        private string content;
        public OneToNine(string content, string resultValue) {
            this.content = content;
            this.resultValue = resultValue;
            InputNum();
        }

        private void InputNum()
        {
            if ("0".Equals(resultValue))
                resultValue = content;
            else
            {
                resultValue += content;
            }
            
        }
        
        public string ReturnResultValue() {
            return resultValue;
        }
    }
}
