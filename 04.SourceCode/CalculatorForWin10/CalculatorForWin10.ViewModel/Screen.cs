using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M;
using NumberDefine;
using CalculatorForWin10;
using Arithmetic;
using Arithmetic.BinaryOperation;
using Arithmetic.UnaryOperation;
using Clean;

namespace CalculatorForWin10.ViewModel
{
    public class Screen
    {
        private static Screen screen = new Screen();
        private string resultValue="0";
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


        //数字定义部分
        public void HandleZero()
        {
            Zero zero = new Zero(resultValue);
            resultValue = zero.ReturnResultValue();
        }
        public void HandleNum(string number)
        {
            OneToNine oneToNine = new OneToNine(number,resultValue);
            resultValue = oneToNine.ReturnResultValue();
        }
        public void HandlePoint()
        {
            Point point = new Point(resultValue);
            resultValue = point.ReturnResultValue();
        }
    }
}
