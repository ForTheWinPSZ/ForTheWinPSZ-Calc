using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public class OneToNine
    {
        private string resultValue;
        private string expressionValue;
        private string content;
        public OneToNine(string content,string resultValue){
            this.content=content;
            this.resultValue = resultValue;
            Add();
        }

        private void Add()
        {
            resultValue += content;
        }

        public string returnResult() {
            return resultValue;
        }
    }
}
