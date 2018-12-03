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
using System.Diagnostics;

namespace CalculatorForWin10.ViewModel
{
    public class Screen
    {
        private static Screen screen = new Screen();
        private string resultValue="0";
        private string expressionValue="";
        private List<string> history;
        private List<string> memory = new List<string>();

        private Screen() { }
        public static Screen GetScreen()
        {
            return screen;
        }

        public string GetResult()
        {
            //写在这里的目的是，不改变resultValue的值，只是为了改变屏幕上resultValue的显示
            return Comma.AddComma(resultValue);
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
            foreach (string m in memory)
            {
                Debug.WriteLine(m);
            }
            return memory;
        }

        
        public void HandleMc()
        {
            MC mc = new MC(memory);
            memory = mc.CleanAll();
        }
        public void HandleMr()
        {
            MR mr = new MR(memory,resultValue);
            resultValue = mr.ReUse();
        }
        public void HandleMplus()
        {
            MPlus mPlus = new MPlus(memory,resultValue);
            memory = mPlus.FirstPlus();
        }
        public void HandleMminus()
        {
            MMinus mMinus = new MMinus(memory, resultValue);
            memory = mMinus.FirstMinus();
        }
        public void HandleMs()
        {
            M.MS ms = new M.MS(memory,resultValue);
            memory = ms.AddMemory(resultValue);
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
            BackSpace backSpace = new BackSpace(resultValue);
            resultValue = backSpace.BackSp();
        }
       
        public void HandleSquareroot()
        {
        }
        
        public void HandleSquare()
        {
        }
       
        
        public void HandleReciprocal()
        {
        }
        public void HandleReverse()
        {
            IUnary reverse = new Reverse(expressionValue,resultValue);
            resultValue = reverse.ChangeResultValue();
            expressionValue = reverse.ChangeExpression();
        }
        public void HandleEqual()
        {
        }


        //双目运算部分
        public void HandleDivision()
        {
            IBinary division = new Division(resultValue, expressionValue);
            resultValue = division.ChangeResultValue();
            expressionValue = division.ChangeExpression();
        }
        public void HandlePlus()
        {
            IBinary plus = new Plus(resultValue,expressionValue);
            resultValue = plus.ChangeResultValue();
            expressionValue = plus.ChangeExpression();
        }
        public void HandleMinus()
        {
            IBinary minus = new Minus(resultValue,expressionValue);
            resultValue = minus.ChangeResultValue();
            expressionValue = minus.ChangeExpression();
        }
        public void HandleMultiplication()
        {
            IBinary mul=new Multiplication(resultValue, expressionValue);
            resultValue = mul.ChangeResultValue();
            expressionValue = mul.ChangeExpression();
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
