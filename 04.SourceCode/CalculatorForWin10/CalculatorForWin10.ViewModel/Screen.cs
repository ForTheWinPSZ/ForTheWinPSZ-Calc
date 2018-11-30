using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Number;
using System.Diagnostics;

namespace CalculatorForWin10.ViewModel
{
    public class Screen
    {
        private string resultValue = "0";
        private string expressionValue = "";

        public string ResultValue { get => resultValue; set => resultValue = value; }
        public string ExpressionValue { get => expressionValue; set => expressionValue = value; }


        public void InputOneToNine(string num)
        {
            Debug.WriteLine("传入"+num);
            OneToNine oneToNine = new OneToNine(resultValue);
            resultValue = oneToNine.InputNumber(num);
        }
    }
}
