using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public abstract class Unary
    {
        private string resultValue;
        private string expressionValue;
        private bool isBinary;

        public abstract string Expression();
        public abstract string IsUnary();
        public abstract string IsBinary();
        public abstract string ChangeResultValue();
        public abstract string ChangeExpression();
    }
}
