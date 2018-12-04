using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class BackSpace
    {
        private string resultValue;
        private double result;

        public BackSpace(string resultValue)
        {
            this.resultValue = resultValue;
            result = Convert.ToDouble(resultValue);
            BackSp();
        }

        public void BackSp()
        {
            if (result>0)
            {
                if (resultValue.Length > 1)
                {
                    resultValue = resultValue.Remove(resultValue.Length - 1);
                }
                else
                {
                    resultValue = "0";
                }
            }
            else
            {
                if (resultValue.Equals("-0.")|| resultValue.Length <= 2)
                {
                    resultValue = "0";
                }
                else 
                {
                    resultValue = resultValue.Remove(resultValue.Length - 1);
                }
            }
            
        }

        public string ReturnResultValue()
        {
            return resultValue;
        }
    }
}
