using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.BinaryOperation
{
    public abstract class IBinary
    {
        protected string resultValue;
        protected string expressionValue;
        protected string preResult;
        private bool isComplete=true;

        public bool IsComplete { get => isComplete; set => isComplete = value; }

        public abstract void ChangeExpression();

        public abstract void ChangeResultValue();
        public abstract string ReturnResultValue();
        public abstract string ReturnExpressionValue();

        public abstract string ReturnPreResult();
    }
}
