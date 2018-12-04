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
        private string preUnaryResult = "";

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
            return Comma.AddComma(preResult);
        }

        public string GetPreUnaryResult()
        {
            return Comma.AddComma(preUnaryResult);
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
            IClear ce = new CE(resultValue,expressionValue,preResult);
            resultValue = ce.ReturnResultValue();
            expressionValue = ce.ReturnExpressionValue();
            preResult = ce.ReturnPreResult();
        }
        public void HandleC()
        {
            C c = new C(resultValue,expressionValue,preResult,preUnaryResult);
            resultValue = c.ReturnResultValue();
            expressionValue = c.ReturnExpressionValue();
            preResult = c.ReturnPreResult();
            preUnaryResult = c.ReturnPreUnaryResult();
        }
        public void HandleDel()
        {
            BackSpace bs = new BackSpace(resultValue, expressionValue, preResult);
            resultValue = bs.ReturnResultValue();
            expressionValue = bs.ReturnExpressionValue();
            preResult = bs.ReturnPreResult();
        }
       
        //单目运算
        public void HandleSquareroot()
        {
            IUnary squareRoot = new SquareRoot(expressionValue, resultValue, preUnaryResult,preResult);
            expressionValue = squareRoot.ReturnExpressionValue();
            resultValue = squareRoot.ReturnResultValue();
            preUnaryResult = squareRoot.ReturnPreUnaryResult();
        }
        
        public void HandleSquare()
        {
            IUnary square = new Square(expressionValue,resultValue,preUnaryResult,preResult);
            expressionValue = square.ReturnExpressionValue();
            resultValue = square.ReturnResultValue();
            preUnaryResult = square.ReturnPreUnaryResult();
        }
       
        
        public void HandleReciprocal()
        {
            IUnary rec = new Reciprocal(expressionValue, resultValue, preUnaryResult,preResult);
            expressionValue = rec.ReturnExpressionValue();
            resultValue = rec.ReturnResultValue();
            preUnaryResult = rec.ReturnPreUnaryResult();
        }
        public void HandleReverse()
        {
            IUnary reverse = new Reverse(expressionValue, resultValue, preUnaryResult, preResult);
            expressionValue = reverse.ReturnExpressionValue();
            resultValue = reverse.ReturnResultValue();
            preUnaryResult = reverse.ReturnPreUnaryResult();
        }


        public void HandleEqual()
        {
        }


        //双目运算部分
        public void HandleDivision()
        {
            IBinary division = new Division(resultValue, expressionValue,preResult);
                preResult = division.ReturnPreResult();
                resultValue = "";
                expressionValue = division.ReturnExpressionValue();
            
        }
        public void HandlePlus()
        {
            IBinary plus = new Plus(resultValue,expressionValue,preResult);
                preResult = plus.ReturnPreResult();
                resultValue = "";
                expressionValue = plus.ReturnExpressionValue();
            
            
        }
        public void HandleMinus()
        {
            IBinary minus = new Minus(resultValue,expressionValue,preResult);           
                preResult = minus.ReturnPreResult();
                resultValue = "";
                expressionValue = minus.ReturnExpressionValue();
            
        }
        public void HandleMultiplication()
        {
            IBinary mul=new Multiplication(resultValue, expressionValue,preResult);            
                preResult = mul.ReturnPreResult();
                resultValue = "";
                expressionValue = mul.ReturnExpressionValue();
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
