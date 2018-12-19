using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class CE 
    {
        private string _resultValue;
        private string _expressionValue;

        public CE(string resultValue,string expressionValue)
        {
            this._resultValue = resultValue;
            this._expressionValue = expressionValue;
            ClearResultValue();
            ChangeExpression();
        }
        public void ChangeExpression()
        {
          
            if (_expressionValue != ""&&!_expressionValue.EndsWith(" "))
            {
                string[] arr = _expressionValue.Split(new char[] { ' ' });
                _expressionValue=_expressionValue.Replace(arr[arr.Length-1],"");
            }
            
        }
        public void ClearResultValue()
        {
            _resultValue = "0";
        }
        
        public string ReturnResultValue()
        {
            return _resultValue;
        }
        public string ReturnExpressionValue()
        {
            return _expressionValue;
        }
    }
}
