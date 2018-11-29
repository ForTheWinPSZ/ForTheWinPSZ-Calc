using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForWin10.ViewModel
{
    class Screen
    {
        private string resultValue;
        private string expressionValue;

        private static Screen screen = new Screen();

        public string ResultValue { get => resultValue; set => resultValue = value; }
        public string ExpressionValue { get => expressionValue; set => expressionValue = value; }

        private Screen() { }

        public static Screen GetScreen() {
            return screen;
        }
    }
}
