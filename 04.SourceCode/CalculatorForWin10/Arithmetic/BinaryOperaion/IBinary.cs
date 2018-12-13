using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.BinaryOperation
{
    public abstract class IBinary
    {
        private string _resultValue;
        private string _expressionValue;
        private string _preResult;
        protected string ResultValue { get => _resultValue; set => _resultValue = value; }
        protected string ExpressionValue { get => _expressionValue; set => _expressionValue = value; }
        protected string PreResult { get => _preResult; set => _preResult = value; }

        public IBinary(string resultValue, string expressionValue, string preResult)        {            ResultValue = resultValue;            ExpressionValue = expressionValue;            PreResult = preResult;                        Change();        }

        public abstract void Change();
        public string ReturnResultValue()
        {
            return ResultValue;
        }
        public string ReturnExpressionValue()
        {
            return ExpressionValue;
        }

        public string ReturnPreResult()
        {
            return PreResult;
        }
    }
}
