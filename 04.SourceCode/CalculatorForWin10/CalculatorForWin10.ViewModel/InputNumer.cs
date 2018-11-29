using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForWin10.ViewModel
{
    public class InputNumer : INumber
    {
        public string InputNum(string num)
        {
            if (Screen.ResultValue == "0")
            {
                if (num != ".")
                {
                    Screen.ResultValue = num;
                }
                else
                {
                    Screen.ResultValue = "0.";
                }
            }
            else
            {
                if (Screen.ResultValue.Contains("."))
                {
                    if (num == ".")
                    {
                        
                    }
                }
            }
            return Screen.ResultValue;
        }
    }
}
