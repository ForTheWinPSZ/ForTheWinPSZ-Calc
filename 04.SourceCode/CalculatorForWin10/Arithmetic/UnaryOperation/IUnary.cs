using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.UnaryOperation
{
    public abstract class IUnary
    {
        protected bool _canNumberDef;
        private string _resultValue;
        private string _expressionValue;
        private string _preResult;
        protected int binaryIndex;
        protected string displayText = "";
        protected string ResultValue { get => _resultValue; set => _resultValue = value; }
        protected string ExpressionValue { get => _expressionValue; set => _expressionValue = value; }
        protected string PreResult { get => _preResult; set => _preResult = value; }
        public IUnary(string expressionValue, string resultValue, string preResult)        {            ExpressionValue = expressionValue;            ResultValue = resultValue;            PreResult = preResult;
            if (resultValue.Contains(".")&&!resultValue.Contains("e"))            {                resultValue = Convert.ToDecimal(resultValue).ToString();            }
                    }
        public string GetUnaryExpression()        {            binaryIndex = ExpressionValue.LastIndexOf(" ") + 1;            return ExpressionValue.Substring(binaryIndex);        }
        public abstract void ChangeResultValue();
        public abstract void ChangeExpression();
        public string ReturnExpressionValue()        {            return ExpressionValue;        } 
        public string ReturnResultValue()        {            return ResultValue;        }
    }
}
