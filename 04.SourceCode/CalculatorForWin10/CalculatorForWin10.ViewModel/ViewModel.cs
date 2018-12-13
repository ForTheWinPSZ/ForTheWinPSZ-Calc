using Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Arithmetic;


namespace CalculatorForWin10.ViewModel
{
    public class MainWindowsViewModel : NotifyObject
    {
        Screen screen = Screen.GetScreen();
        #region 按钮委托
        private readonly NVCommand btn_mc;
        public NVCommand Btn_mc{ get => btn_mc; }
        private readonly NVCommand btn_mr;
        public NVCommand Btn_mr { get => btn_mr; }
        private readonly NVCommand btn_mplus;
        public NVCommand Btn_mplus { get => btn_mplus; }
        private readonly NVCommand btn_mminus;
        public NVCommand Btn_mminus { get => btn_mminus; }
        private readonly NVCommand btn_ms;
        public NVCommand Btn_ms { get => btn_ms; }
        private readonly NVCommand btn_pre;
        public NVCommand Btn_pre { get => btn_pre; }
        private readonly NVCommand btn_ce;
        public NVCommand Btn_ce { get => btn_ce; }
        private readonly NVCommand btn_c;
        public NVCommand Btn_c { get => btn_c; }
        private readonly NVCommand btn_del;
        public NVCommand Btn_del { get => btn_del; }
        private readonly NVCommand btn_division;
        public NVCommand Btn_division { get => btn_division; }
        private readonly NVCommand btn_squareroot;
        public NVCommand Btn_squareroot { get => btn_squareroot; }
        private readonly NVCommand btn_7;
        public NVCommand Btn_7 { get => btn_7; }
        private readonly NVCommand btn_8;
        public NVCommand Btn_8 { get => btn_8; }
        private readonly NVCommand btn_9;
        public NVCommand Btn_9 { get => btn_9; }
        private readonly NVCommand btn_multiplication;
        public NVCommand Btn_multiplication { get => btn_multiplication; }
        private readonly NVCommand btn_square;
        public NVCommand Btn_square { get => btn_square; }
        private readonly NVCommand btn_4;
        public NVCommand Btn_4 { get => btn_4; }
        private readonly NVCommand btn_5;
        public NVCommand Btn_5 { get => btn_5; }
        private readonly NVCommand btn_6;
        public NVCommand Btn_6 { get => btn_6; }
        private readonly NVCommand btn_minus;
        public NVCommand Btn_minus { get => btn_minus; }
        private readonly NVCommand btn_1;
        public NVCommand Btn_1 { get => btn_1; }
        private readonly NVCommand btn_2;
        public NVCommand Btn_2 { get => btn_2; }
        private readonly NVCommand btn_3;
        public NVCommand Btn_3 { get => btn_3; }
        private readonly NVCommand btn_plus;
        public NVCommand Btn_plus { get => btn_plus; }
        private readonly NVCommand btn_reciprocal;
        public NVCommand Btn_reciprocal { get => btn_reciprocal; }
        private readonly NVCommand btn_reverse;
        public NVCommand Btn_reverse { get => btn_reverse; }
        private readonly NVCommand btn_0;
        public NVCommand Btn_0 { get => btn_0; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_equal;
        public NVCommand Btn_equal { get => btn_equal; }
        private readonly NVCommand btn_qc;
        public NVCommand Btn_qc { get => btn_qc; }

        private readonly NVCommand btn_qc1;
        public NVCommand Btn_qc1 { get => btn_qc1; }
        #endregion
        public MainWindowsViewModel()
        {
            #region 委托调用方法
            btn_qc1 = new NVCommand(Dustbin1);
            btn_mc = new NVCommand(Mc);
            btn_mr = new NVCommand(Mr);
            btn_mplus = new NVCommand(Mplus);
            btn_mminus = new NVCommand(Mminus);
            btn_ms = new NVCommand(Ms);
            btn_pre = new NVCommand(Pre);
            btn_ce = new NVCommand(Ce);
            btn_c = new NVCommand(C);
            btn_del = new NVCommand(Del);
            btn_division = new NVCommand(Division);
            btn_squareroot = new NVCommand(Squareroot);
            btn_multiplication = new NVCommand(Multiplication);
            btn_square = new NVCommand(Square);
            btn_minus = new NVCommand(Minus);
            btn_plus = new NVCommand(Plus);
            btn_reciprocal = new NVCommand(Reciprocal);
            btn_reverse = new NVCommand(Reverse);
            btn_point = new NVCommand(Point);
            btn_equal = new NVCommand(Equal);
            btn_0 = new NVCommand(Zero);
            btn_1= new NVCommand(One);
            btn_2 = new NVCommand(Two);
            btn_3 = new NVCommand(Three);
            btn_4 = new NVCommand(Four);
            btn_5 = new NVCommand(Five);
            btn_6 = new NVCommand(Six);
            btn_7 = new NVCommand(Seven);
            btn_8 = new NVCommand(Eight);
            btn_9 = new NVCommand(Nine);
            btn_qc = new NVCommand(Dustbin);
            #endregion
        }
        #region 内存
        private void Mc()
        {
            screen.HandleMc();
            Memory.Clear();
            
        }

        private void Mr()
        {
            screen.HandleMr();
            ResultText = screen.GetResult();
        }
        private void Mplus()
        {
            screen.HandleMplus();
            Memory.Clear();
            foreach (var item in screen.Memory())
            {
                Memory.Insert(0, item);
            }
        }
        private void Mminus()
        {
            screen.HandleMminus();
            Memory.Clear();
            foreach (var item in screen.Memory())
            {
                Memory.Insert(0, item);
            }
        }
        private void Ms()
        {
            screen.HandleMs();
            Memory.Clear();
            foreach (var item in screen.Memory())
            {
                Memory.Insert(0,item);
            }
        }
        #endregion

        #region 清除
        private void Ce()
        {
            screen.HandleCe();
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
        }
        private void C()
        {
            screen.HandleC();
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
        }
        private void Del()
        {
            screen.HandleDel();
            ResultText = screen.GetResult();
        }
        private void Dustbin()
        {
            screen.HandleDustbin();
            History.Clear();
            foreach (var item in screen.History())
            {
                History.Insert(0, item);
            }
        }

        private void Dustbin1()

        {

            screen.HandleDustbin1();

            Memory.Clear();

            foreach (var item in screen.Memory())

            {

                Memory.Insert(0, item);

            }

        }

        #endregion

        #region 单目运算
        private void Squareroot()
        {
            screen.HandleSquareroot();
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
        }

        private void Square()
        {
            screen.HandleSquare();
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
        }
        private void Reciprocal()
        {
            screen.HandleReciprocal();
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
        }
        private void Reverse()
        {
            screen.HandleReverse();
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
        }
        private void Pre()
        {
            screen.HandlePre();
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
        }
        #endregion

        #region 双目运算
        private void Plus()
        {
            screen.HandlePlus();
            if (screen.GetResult() == "")
            {
                ResultText = screen.GetPreResult();
            }
            else
            {
                ResultText = screen.GetResult();
            }
            ExpressionText = screen.GetExpressionValue();
        }
        private void Minus()
        {
            screen.HandleMinus();
            if (screen.GetResult() == "")
            {
                ResultText = screen.GetPreResult();
            }
            else
            {
                ResultText = screen.GetResult();
            }
            ExpressionText = screen.GetExpressionValue();
        }
        private void Multiplication()
        {
            screen.HandleMultiplication();
            if (screen.GetResult() == "")
            {
                ResultText = screen.GetPreResult();
            }
            else
            {
                ResultText = screen.GetResult();
            }
            ExpressionText = screen.GetExpressionValue();
        }
        private void Division()
        {
            screen.HandleDivision();
            if (screen.GetResult() == "")
            {
                ResultText = screen.GetPreResult();
            }
            else
            {
                ResultText = screen.GetResult();
            }
            ExpressionText = screen.GetExpressionValue();
        }
        #endregion

        #region 数字定义部分
        private void Zero()
        {
            screen.HandleZero("0");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Point()
        {
            screen.HandlePoint(".");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void One()
        {
            screen.HandleNum("1");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Two()
        {
            screen.HandleNum("2");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Three()
        {
            screen.HandleNum("3");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Four()
        {
            screen.HandleNum("4");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Five()
        {
            screen.HandleNum("5");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Six()
        {
            screen.HandleNum("6");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Seven()
        {
            screen.HandleNum("7");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Eight()
        {
            screen.HandleNum("8");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        private void Nine()
        {
            screen.HandleNum("9");
            ResultText = screen.GetResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        #endregion

        #region 等于
        private void Equal()
        {
            screen.HandleEqual();
            ResultText = screen.GetPreResult();
            ExpressionText = screen.GetExpressionValue();
            ShowHistroy();
        }
        #endregion

        #region 屏幕显示部分
        private string _resultText="0";
        public string ResultText
        {
            get { return _resultText; }
            set { SetPropertyNotify(ref _resultText, value, nameof(ResultText)); }
        }
        private string _expressionText="";
        public string ExpressionText
        {
            get { return _expressionText; }
            set { SetPropertyNotify(ref _expressionText, value, nameof(ExpressionText)); }
        }
        private ObservableCollection<History> _history = new ObservableCollection<History>() { new History("", "尚无历史记录") };
        public ObservableCollection<History> History
        {
            get { return _history; }
        }
        private ObservableCollection<string> _memory =new ObservableCollection<string>() {"内存中没有内容"};
        public ObservableCollection<string> Memory
        {
            get { return _memory; }
        }
        #endregion
        
        private void ShowHistroy()
        {
            History.Clear();
            foreach (var item in screen.History())
            {
                History.Insert(0, item);
            }
        }
    }
}
