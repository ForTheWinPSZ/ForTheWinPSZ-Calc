using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public abstract class Binary
    {
        private string resultValue;
        private string expressionValue;
        private bool isComplete;

        public abstract string ChangeExpression();

        public abstract string ChangeResultValue();
    }
}
