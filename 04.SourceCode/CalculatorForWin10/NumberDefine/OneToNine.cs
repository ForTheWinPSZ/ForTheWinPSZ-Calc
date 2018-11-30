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
        public OneToNine(string content,string resultValue,string expressionValue){
            this.content=content;
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
            Add();
        }

        private void Add()
        {
            resultValue += content;
        }

        public string returnResult() {
            return resultValue;
        }
        public string returnExpressionValue()
        {
            return expressionValue;
        }
    }
}
