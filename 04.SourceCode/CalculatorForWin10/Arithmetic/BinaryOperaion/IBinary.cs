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
        
        public abstract void ChangeExpression();

        public abstract void ChangeResultValue();
        public abstract string ReturnResultValue();
        public abstract string ReturnExpressionValue();

        public abstract string ReturnPreResult();
    }
}
