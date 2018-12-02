using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Arithmetic.BinaryOperation
{
    public class Multiplication : IBinary
    {
        public Multiplication(string value1, string value2)
        {
            base.resultValue = value1;
            base.expressionValue = value2;
            if (".".Equals(resultValue.Substring(resultValue.Length - 1)))
            {
                resultValue = resultValue.Substring(0, resultValue.Length - 1);
            }
        }

        public override string ChangeExpression()
        {
            if (expressionValue == "")
            {
                return resultValue + "x";
            }
            else
            {
                string express = expressionValue.Substring(expressionValue.Length - 1);
                Regex regex = new Regex(@"\d");
                if (!regex.IsMatch(@"\d"))
                {
                    return expressionValue.Substring(0, expressionValue.Length - 1) + "x";
                }
                return expressionValue + resultValue + "x";
            }
        }

        public override string ChangeResultValue()
        {
            return resultValue;
        }
    }
}
