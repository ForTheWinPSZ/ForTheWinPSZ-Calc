using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public class Equal
    {
        private string resultValue;

        private string expressionValue;

        private string preResult;

        private List<string> history;

        private double result;



        public Equal(string resultValue, string expressionValue, string preResult, List<string> history)

        {

            this.resultValue = resultValue;

            this.expressionValue = expressionValue;

            this.preResult = preResult;

            this.history = history;

        }



        public string ExpressionResult()

        {

            return "";

        }



        public string CaculationResult()

        {
            if (preResult.Equals("") && resultValue.Equals(""))
            {

            }


            if (preResult.Equals(""))

            {
                string exps = expressionValue.Trim().Replace(" ","");

                if (exps.EndsWith("+"))

                {

                    result = Convert.ToDouble(exps.Substring(0, 1)) + Convert.ToDouble(resultValue);

                }

                if (exps.EndsWith("-"))

                {

                    result = Convert.ToDouble(exps.Substring(0, 1)) - Convert.ToDouble(resultValue);

                }

                if (expressionValue.EndsWith("x"))

                {

                    result = Convert.ToDouble(expressionValue.Substring(0, 1)) * Convert.ToDouble(resultValue);

                }

                if (expressionValue.EndsWith("÷"))

                {

                    result = Convert.ToDouble(expressionValue.Substring(0, 1)) / Convert.ToDouble(resultValue);

                }

            }

            else

            {

                if (expressionValue.EndsWith("+"))

                {

                    result = Convert.ToDouble(preResult) + Convert.ToDouble(resultValue);

                }

                if (expressionValue.EndsWith("-"))

                {

                    result = Convert.ToDouble(preResult) - Convert.ToDouble(resultValue);

                }

                if (expressionValue.EndsWith("x"))

                {

                    result = Convert.ToDouble(preResult) * Convert.ToDouble(resultValue);

                }

                if (expressionValue.EndsWith("÷"))

                {

                    result = Convert.ToDouble(preResult) / Convert.ToDouble(resultValue);

                }

            }



            return Convert.ToString(result);

        }



        public List<string> AddHistory(string expression)

        {

            return history;

        }

    }

}
