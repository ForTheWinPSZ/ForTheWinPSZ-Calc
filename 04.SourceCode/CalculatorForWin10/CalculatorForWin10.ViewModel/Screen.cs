using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M;
using NumberDefine;
using CalculatorForWin10;

namespace CalculatorForWin10.ViewModel
{
    public class Screen
    {
        private static Screen screen = new Screen();
        private string resultValue;
        private string expressionValue;

        private Screen() { }
        public static Screen GetScreen()
        {
            return screen;
        }

        public string GetResult()
        {
            return resultValue;
        }

        public string GetexpressionValue()
        {
            return expressionValue;
        }

        public void Point()
        {
             
        }
        public void Num(string number)
        {
            OneToNine oneToNine = new OneToNine(number,resultValue,expressionValue);
            resultValue = oneToNine.returnResult();
        }

    }
}
