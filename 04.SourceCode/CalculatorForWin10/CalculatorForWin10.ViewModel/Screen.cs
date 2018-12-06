﻿using System;
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
        private static Screen _screen = new Screen();
        private string _resultValue = "0";
        private string _expressionValue = "";
        private List<string> _history = new List<string>();
        private List<string> _memory = new List<string>();
        private string _preResult = "";
        private string _lparm = "";
        private bool _canNumberDef = true;

        //获取Screen
        public static Screen GetScreen()
        {
            return _screen;
        }

        #region 返回给model，界面显示
        public string GetResult()
        {
            //不改变_resultValue的值，改变屏幕上_resultValue的显示
            return Comma.AddComma(_resultValue);
        }

        public string GetExpressionValue()
        {
            return _expressionValue;
        }
        public string GetPreResult()
        {
            return Comma.AddComma(_preResult);
        }

        public List<string> History()
        {
            return _history;
        }
        public List<string> Memory()
        {
            return _memory;
        }
        #endregion

        #region 处理内存按钮
        public void HandleMc()
        {
            MC mc = new MC(_memory);
            _memory = mc.CleanAll();
        }
        public void HandleMr()
        {
            MR mr = new MR(_memory, _resultValue);
            _resultValue = mr.ReUse();
        }
        public void HandleMplus()
        {
            MPlus mPlus = new MPlus(_memory, _resultValue);
            _memory = mPlus.FirstPlus();
        }
        public void HandleMminus()
        {
            MMinus mMinus = new MMinus(_memory, _resultValue);
            _memory = mMinus.FirstMinus();
        }
        public void HandleMs()
        {
            M.MS ms = new M.MS(_memory, _resultValue,_preResult);
            _memory = ms.AddMemory(_resultValue);
        }
        #endregion

        #region 处理双目运算

        public void HandlePlus()
        {
            IBinary plus = new Plus(_resultValue, _expressionValue, _preResult);
            _preResult = plus.ReturnPreResult();
            _expressionValue = plus.ReturnExpressionValue();
            _resultValue = "";
            _canNumberDef = false;
        }
        public void HandleMinus()
        {
            IBinary minus = new Minus(_resultValue, _expressionValue, _preResult);
            _preResult = minus.ReturnPreResult();
            _expressionValue = minus.ReturnExpressionValue();
            _resultValue = "";
            _canNumberDef = false;
        }
        public void HandleMultiplication()
        {
            IBinary mul = new Multiplication(_resultValue, _expressionValue, _preResult);
            _preResult = mul.ReturnPreResult();
            _expressionValue = mul.ReturnExpressionValue();
            _resultValue = "";
            _canNumberDef = false;
        }
        public void HandleDivision()
        {
            IBinary division = new Division(_resultValue, _expressionValue, _preResult);
            _preResult = division.ReturnPreResult();
            _expressionValue = division.ReturnExpressionValue();
            _resultValue = "";
            _canNumberDef = false;
        }
        #endregion

        #region 处理单目运算
        public void HandleSquareroot()
        {
            IUnary squareRoot = new SquareRoot(_expressionValue, _resultValue, _preResult);
            _expressionValue = squareRoot.ReturnExpressionValue();
            _resultValue = squareRoot.ReturnResultValue();
            _canNumberDef = false;
        }

        public void HandleSquare()
        {
            IUnary square = new Square(_expressionValue, _resultValue,_preResult);
            _expressionValue = square.ReturnExpressionValue();
            _resultValue = square.ReturnResultValue();
            _canNumberDef = false;
        }


        public void HandleReciprocal()
        {
            IUnary rec = new Reciprocal(_expressionValue, _resultValue, _preResult);
            _expressionValue = rec.ReturnExpressionValue();
            _resultValue = rec.ReturnResultValue();
            _canNumberDef = false;
        }
        public void HandleReverse()
        {
            Reverse reverse = new Reverse(_expressionValue, _resultValue, _preResult,_canNumberDef);
            _expressionValue = reverse.ReturnExpressionValue();
            _resultValue = reverse.ReturnResultValue();
            _canNumberDef = reverse.ReturnCanNumberDef();
        }
        public void HandlePre()
        {
            IUnary percent = new Percent(_expressionValue, _resultValue, _preResult);
            _expressionValue = percent.ReturnExpressionValue();
            _resultValue = percent.ReturnResultValue();
            _canNumberDef = false;
        }
        #endregion

        #region 处理等于按钮
        public void HandleEqual()        {            Equal equal = new Equal(_resultValue, _expressionValue, _preResult, _history,_lparm);            _expressionValue = equal.ReturnExpressionValue();            _preResult = equal.ReturnPreResult();            _resultValue = "";            _history = equal.ReturnHistory();            foreach (string h in _history)            {                Debug.WriteLine("历史记录：" + h);            }            _canNumberDef = false;            _lparm = equal.Lparm();        }
        #endregion

        #region 处理清除按钮
        public void HandleCe()
        {
            CE ce = new CE(_resultValue, _expressionValue);
            _resultValue = ce.ReturnResultValue();
            _expressionValue = ce.ReturnExpressionValue();
        }
        public void HandleC()
        {
            C c = new C(_resultValue, _expressionValue, _preResult);
            _resultValue = c.ReturnResultValue();
            _expressionValue = c.ReturnExpressionValue();
            _preResult = c.ReturnPreResult();
        }
        public void HandleDel()
        {
            BackSpace bs = new BackSpace(_resultValue,_preResult, _canNumberDef);
            _resultValue = bs.ReturnResultValue();
        }
        public void HandleDustbin()

        {

            Dustbin db = new Dustbin(_history);

            _history = db.Clear();

        }

        public void HandleDustbin1()

        {

            Dustbin db = new Dustbin(_memory);

            _memory = db.Clear();

        }
        #endregion

        #region 数字定义
        public void HandleZero()
        {
            Zero zero = new Zero(_resultValue,_canNumberDef);
            _resultValue = zero.ReturnResultValue();
            _canNumberDef = zero.ReturnCanNumberDef();
        }
        public void HandleNum(string number)
        {
            OneToNine oneToNine = new OneToNine(number,_resultValue,_canNumberDef,_expressionValue);
            _resultValue = oneToNine.ReturnResultValue();
            _canNumberDef = oneToNine.ReturnCanNumberDef();
            _expressionValue = oneToNine.ReturnExpressionValue();
        }
        public void HandlePoint()
        {
            Point point = new Point(_resultValue,_canNumberDef);
            _resultValue = point.ReturnResultValue();
            _canNumberDef = point.ReturnCanNumberDef();
        }
        #endregion
    }
}
