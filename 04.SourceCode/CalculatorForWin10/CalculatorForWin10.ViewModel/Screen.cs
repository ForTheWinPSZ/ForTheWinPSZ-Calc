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
        private List<string> memory=new List<string>();
        private string preResult = "";

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
        public string GetPreResult()
        {
            return preResult;
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
            MC mc = new MC(memory);
            memory=mc.CleanAll();
        }
        public void HandleMr()
        {
            MR mr = new MR(memory,resultValue);
            resultValue=mr.ReUse();
        }
        public void HandleMplus()
        {
            MPlus mPlus = new MPlus(memory,resultValue);
            memory=mPlus.FirstPlus();
        }
        public void HandleMminus()
        {
            MMinus mMinus = new MMinus(memory, resultValue);
            memory =mMinus.FirstMinus();
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
            IClear ce = new CE(resultValue);
            resultValue = ce.ReturnResultValue();
        }
        public void HandleC()
        {
            IClear c = new C(resultValue,expressionValue);
            resultValue = c.ReturnResultValue();
            expressionValue = c.ReturnExpressionValue();
        }
        public void HandleDel()
        {
            BackSpace bs = new BackSpace(resultValue);
            resultValue = bs.ReturnResultValue();
        }
       
        //单目运算
        public void HandleSquareroot()
        {
            IUnary squareRoot = new SquareRoot(expressionValue, resultValue);
            expressionValue = squareRoot.ReturnExpressionValue();
            resultValue = squareRoot.ReturnResultValue();
        }
        
        public void HandleSquare()
        {
            IUnary square = new Square(expressionValue,resultValue);
            expressionValue = square.ReturnExpressionValue();
            resultValue = square.ReturnResultValue();
        }
       
        
        public void HandleReciprocal()
        {
            IUnary rec = new Reciprocal(expressionValue, resultValue);
            expressionValue = rec.ReturnExpressionValue();
            resultValue = rec.ReturnResultValue();
        }
        public void HandleReverse()
        {
        }
        public void HandleEqual()
        {
        }


        //双目运算部分
        public void HandleDivision()
        {
            IBinary division = new Division(resultValue, expressionValue,preResult);
            if (!division.IsComplete)
            {
                resultValue = "";
                expressionValue = division.ReturnExpressionValue();
            }
            else
            {
                preResult = division.ReturnPreResult();
                resultValue = "";
                expressionValue = division.ReturnExpressionValue();
            }
            
        }
        public void HandlePlus()
        {
            IBinary plus = new Plus(resultValue,expressionValue,preResult);
            if (!plus.IsComplete )
            {
                resultValue = "";
                expressionValue = plus.ReturnExpressionValue();
            }
            else
            {
                preResult = plus.ReturnPreResult();
                resultValue = "";
                expressionValue = plus.ReturnExpressionValue();
            }
            
            
        }
        public void HandleMinus()
        {
            IBinary minus = new Minus(resultValue,expressionValue,preResult);
            if (!minus.IsComplete)
            {
                resultValue = "";
                expressionValue = minus.ReturnExpressionValue();
            }
            else
            {
                preResult = minus.ReturnPreResult();
                resultValue = "";
                expressionValue = minus.ReturnExpressionValue();
            }
            
        }
        public void HandleMultiplication()
        {
            IBinary mul=new Multiplication(resultValue, expressionValue,preResult);
            if (!mul.IsComplete)
            {
                resultValue = "";
                expressionValue = mul.ReturnExpressionValue();
            }
            else
            {
                preResult = mul.ReturnPreResult();
                resultValue = "";
                expressionValue = mul.ReturnExpressionValue();
            }
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
