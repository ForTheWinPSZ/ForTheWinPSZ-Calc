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
        private List<string> history;
        private List<string> memory;

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
        public List<string> History()
        {
            return history;
        }
        public List<string> Memory()
        {
            return memory;
        }

        public void HandlePoint()
        {  
        }
        public void HandleMc()
        {
        }
        public void HandleMr()
        {
        }
        public void HandleMplus()
        {
        }
        public void HandleMminus()
        {
        }
        public void HandleMs()
        {
        }
        public void HandlePre()
        {
        }
        public void HandleCe()
        {
        }
        public void HandleC()
        {
        }
        public void HandleDel()
        {
        }
        public void HandleDivision()
        {
        }
        public void HandleSquareroot()
        {
        }
        public void HandleMultiplication()
        {
        }
        public void HandleSquare()
        {
        }
        public void HandleMinus()
        {
        }
        public void HandlePlus()
        {
        }
        public void HandleReciprocal()
        {
        }
        public void HandleReverse()
        {
        }
        public void HandleEqual()
        {
        }
        public void HandleZero()
        {
        }
        public void Num(string number)
        {
            OneToNine oneToNine = new OneToNine(number,resultValue,expressionValue);
            resultValue = oneToNine.returnResult();
        }

    }
}
