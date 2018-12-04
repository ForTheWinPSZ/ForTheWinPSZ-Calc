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
        private static Screen _screen = new Screen();
        private string _resultValue = "0";
        private string _expressionValue = "";
        private List<string> _history = new List<string>();
        private List<string> _memory = new List<string>();
        private string _preResult = "";
        
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
            return _preResult;
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
            M.MS ms = new M.MS(_memory, _resultValue);
            _memory = ms.AddMemory(_resultValue);
        }
        #endregion

        #region 处理双目运算

        public void HandlePlus()
        {
            IBinary plus = new Plus(_resultValue, _expressionValue, _preResult);
            _preResult = plus.ReturnPreResult();
            _resultValue = "";
            _expressionValue = plus.ReturnExpressionValue();


        }
        public void HandleMinus()
        {
            IBinary minus = new Minus(_resultValue, _expressionValue, _preResult);
            _preResult = minus.ReturnPreResult();
            _resultValue = "";
            _expressionValue = minus.ReturnExpressionValue();

        }
        public void HandleMultiplication()
        {
            IBinary mul = new Multiplication(_resultValue, _expressionValue, _preResult);
            _preResult = mul.ReturnPreResult();
            _resultValue = "";
            _expressionValue = mul.ReturnExpressionValue();
        }
        public void HandleDivision()
        {
            IBinary division = new Division(_resultValue, _expressionValue, _preResult);
            _preResult = division.ReturnPreResult();
            _resultValue = "";
            _expressionValue = division.ReturnExpressionValue();

        }
        #endregion

        #region 处理单目运算
        public void HandleSquareroot()
        {
            IUnary squareRoot = new SquareRoot(_expressionValue, _resultValue);
            _expressionValue = squareRoot.ReturnExpressionValue();
            _resultValue = squareRoot.ReturnResultValue();
        }
        
        public void HandleSquare()
        {
            IUnary square = new Square(_expressionValue,_resultValue);
            _expressionValue = square.ReturnExpressionValue();
            _resultValue = square.ReturnResultValue();
        }
       
        
        public void HandleReciprocal()
        {
            IUnary rec = new Reciprocal(_expressionValue, _resultValue);
            _expressionValue = rec.ReturnExpressionValue();
            _resultValue = rec.ReturnResultValue();
        }
        public void HandleReverse()
        {
            Reverse reverse = new Reverse(_resultValue,_expressionValue);
            reverse.ChangeResultValue();
            _resultValue = reverse.ReturnResultValue();
        }
        public void HandlePre()
        {
        }
        #endregion

        #region 处理等于按钮
        public void HandleEqual()
        {
            Equal equal = new Equal(_resultValue, _expressionValue, _preResult,_history);
            _expressionValue = equal.ExpressionResult();
            _resultValue = equal.CaculationResult();
        }
        #endregion

        #region 处理清除按钮
        public void HandleCe()
        {
            IClear ce = new CE(_resultValue);
            _resultValue = ce.ReturnResultValue();
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
            BackSpace bs = new BackSpace(_resultValue);
            _resultValue = bs.ReturnResultValue();
        }
        #endregion

        #region 数字定义
        public void HandleZero()
        {
            Zero zero = new Zero(_resultValue);
            _resultValue = zero.ReturnResultValue();
        }
        public void HandleNum(string number)
        {
            OneToNine oneToNine = new OneToNine(number,_resultValue);
            _resultValue = oneToNine.ReturnResultValue();
        }
        public void HandlePoint()
        {
            Point point = new Point(_resultValue);
            _resultValue = point.ReturnResultValue();
        }
        #endregion
    }
}
