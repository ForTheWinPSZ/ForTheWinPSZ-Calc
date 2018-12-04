using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public class Equal
    {
        private string resultValue;
        private string expressionValue;
        private List<string> history;
        private string preResult;

        public Equal(string resultValue, string expressionValue, List<string> history,string preResult)
        {
            this.resultValue = resultValue;
            this.expressionValue = expressionValue;
            this.history = history;
            this.preResult = preResult;
        }

        public string ExpressionResult()
        {
            return "";
        }

        public string CaculationResult()
        {
            return "";
        }

        public List<string> AddHistory(string expression)
        {
            return history;
        }
    }
}
