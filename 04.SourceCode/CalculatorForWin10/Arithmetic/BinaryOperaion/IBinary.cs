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
        protected bool isComplete;

        

        public abstract string ChangeExpression();

        public abstract string ChangeResultValue();
    }
}
