using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class BackSpace
    {
        private string _resultValue;
        private double _result;

        public BackSpace(string resultValue)
        {
            this._resultValue = resultValue;
            _result = Convert.ToDouble(resultValue);
            BackSp();
        }

        public void BackSp()
        {
            if (_result>0)
            {
                if (_resultValue.Length > 1)
                {
                    _resultValue = _resultValue.Remove(_resultValue.Length - 1);
                }
                else
                {
                    _resultValue = "0";
                }
            }
            else
            {
                if (_resultValue.Equals("-0.")|| _resultValue.Length <= 2)
                {
                    _resultValue = "0";
                }
                else 
                {
                    _resultValue = _resultValue.Remove(_resultValue.Length - 1);
                }
            }
            
        }

        public string ReturnResultValue()
        {
            return _resultValue;
        }
    }
}
