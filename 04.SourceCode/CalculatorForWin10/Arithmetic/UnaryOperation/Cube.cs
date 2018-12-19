using Arithmetic.BinaryOperaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.UnaryOperation
{
    class Cube:IUnary
    {
        public Cube(string expressionValue, string resultValue, string preResult) : base(expressionValue, resultValue, preResult)        {            ChangeResultValue();
            ChangeExpression();        }        public override void ChangeExpression()        {            if (ExpressionValue == "" || ExpressionValue.EndsWith(" ")) //结尾是双目
            {                ExpressionValue += "cube(" + Tool.MaxContain(displayText) + ")";            }            else            {                string UnaryExpression = GetUnaryExpression().Trim();                string partExpression = ExpressionValue.Substring(0, binaryIndex);                ExpressionValue = partExpression + "cube(" + UnaryExpression + ")";            }        }        public override void ChangeResultValue()        {            ResultValue = Tool1.Calculate("cube", displayText = ResultValue == "" ? PreResult : ResultValue);        }

    }
}
