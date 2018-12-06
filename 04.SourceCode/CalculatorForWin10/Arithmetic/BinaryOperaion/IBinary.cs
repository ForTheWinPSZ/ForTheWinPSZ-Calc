using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.BinaryOperation
{
    public abstract class IBinary
    {
        protected string _resultValue;
        protected string _expressionValue;
        protected string _preResult;

        protected string ResultValue { get => _resultValue; set => _resultValue = value; }
        protected string ExpressionValue { get => _expressionValue; set => _expressionValue = value; }
        protected string PreResult { get => _preResult; set => _preResult = value; }
        public abstract void Change();
        
        public abstract string ReturnResultValue();
        public abstract string ReturnExpressionValue();

        public abstract string ReturnPreResult();
    }
}
