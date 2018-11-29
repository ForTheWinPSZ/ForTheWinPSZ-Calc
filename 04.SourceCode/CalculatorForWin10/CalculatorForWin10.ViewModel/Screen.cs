using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForWin10.ViewModel
{
    public class Screen
    {
        private static string resultValue = "0";
        private static string expressionValue = "";

        public static string ResultValue { get => resultValue; set => resultValue = value; }
        public static string ExpressionValue { get => expressionValue; set => expressionValue = value; }
    }
}
