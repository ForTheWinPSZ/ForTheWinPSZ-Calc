using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.UnaryOperation
{
    public interface IUnary
    {
        string Calculate(string param);
        void ChangeResultValue();
        void ChangeExpression();
        string ReturnExpressionValue();
        string ReturnResultValue();
        string GetUnaryExpression();
    }
}
