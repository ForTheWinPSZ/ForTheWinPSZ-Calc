using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class C 
    {
        private string _resultValue;
        private string _expressionValue;
        private string _preResult;

        public C(string resultValue, string expressionValue,string preResult)
        {
            this._resultValue = resultValue;
            this._expressionValue = expressionValue;
            this._preResult = preResult;
            ClearPreResult();
            ClearExpression();
            ClearResultValue();
        }
        public void ClearPreResult()
        {
            _preResult = "";
        }
        public void ClearResultValue()
        {
            _resultValue = "0";
        }

        public void ClearExpression()
        {
            _expressionValue = "";
        }

        public string ReturnResultValue()
        {
            return _resultValue;
        }

        public string ReturnExpressionValue()
        {
            return _expressionValue;
        }

        public string ReturnPreResult()
        {
            return _preResult;
        }

    }
}
