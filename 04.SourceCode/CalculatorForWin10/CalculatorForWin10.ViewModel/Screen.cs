using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M;

namespace CalculatorForWin10.ViewModel
{
    public class Screen
    {
        private string resultValue;
        private string expressionValue;

        public string ResultValue { get => resultValue; set => resultValue = value; }
        public string ExpressionValue { get => expressionValue; set => expressionValue = value; }

        

    }
}
