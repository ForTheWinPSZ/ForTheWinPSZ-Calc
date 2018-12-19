using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForWin10.ViewModel
{
    class Number
    {
        private bool isStartWithZero;
        private bool hasPoint;
        private bool isCalcued;
        private string finalContent;
       
        public bool IsCalcued { get => isCalcued; set => isCalcued = value; }
        public string FinalContent { get => finalContent; set => finalContent = value; }

        public void InputText(string content)
        {
            finalContent += content;
            Screen screen = Screen.GetScreen();
            screen.ResultValue = finalContent;
           
        }

    }
}
