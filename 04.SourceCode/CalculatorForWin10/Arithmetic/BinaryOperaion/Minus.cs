using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Arithmetic.BinaryOperation
{
    public class Minus : IBinary
    {
        public Minus(string value1, string value2)
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
                return resultValue + "-";
            }
            else
            {
                string express = expressionValue.Substring(expressionValue.Length - 1);
                Regex regex = new Regex(@"\d");
                if (!regex.IsMatch(@"\d"))
                {
                    return expressionValue.Substring(0, expressionValue.Length - 1) + "-";
                }
                return expressionValue + resultValue + "-";
            }
        }

        public override string ChangeResultValue()
        {
            return resultValue;
        }
    }
}
