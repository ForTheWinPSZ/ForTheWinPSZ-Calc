using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.UnaryOperation
{
    public class Reverse : IUnary
    {
        private string resultValue;
        private string expressionValue;
        private double result;
        public Reverse(string resultValue, string expressionValue)
        {
            this.expressionValue = expressionValue;
            this.resultValue = resultValue;
        }
        public string Calculate()
        {
            throw new NotImplementedException();
        }

        public void ChangeExpression()
        {
            throw new NotImplementedException();
        }

        public void ChangeResultValue()
        {
            result = -Convert.ToDouble(resultValue);
            resultValue = Convert.ToString(result);
        }

        public string GetUnaryExpression()
        {
            throw new NotImplementedException();
        }

        public bool IsBinary()
        {
            throw new NotImplementedException();
        }

        public bool IsUnary()
        {
            throw new NotImplementedException();
        }

        public string ReturnExpressionValue()
        {
            throw new NotImplementedException();
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }
    }
}
