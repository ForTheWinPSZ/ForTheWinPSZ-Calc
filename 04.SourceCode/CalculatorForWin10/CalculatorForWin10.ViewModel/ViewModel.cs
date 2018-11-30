﻿using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForWin10.ViewModel
{
    public class MainWindowsViewModel : NotifyObject
    {
        Screen screen = Screen.GetScreen();
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

        public MainWindowsViewModel()
        {
            btn_point = new NVCommand(Mc);
            btn_mc = new NVCommand(Mr);
            btn_mr = new NVCommand(Mplus);
            btn_mplus = new NVCommand(Mminus);
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
        }
        private void Point()
        {
            screen.HandlePoint();
            ResultText = screen.GetResult();
        }
        private void Mc()
        {
        }
        private void Mr()
        {
        }
        private void Mplus()
        {
        }
        private void Mminus()
        {
        }
        private void Ms()
        {
        }
        private void Pre()
        {
        }
        private void Ce()
        {
        }
        private void C()
        {
        }
        private void Del()
        {
        }
        private void Division()
        {
        }
        private void Squareroot()
        {
        }
        private void Multiplication()
        {
        }
        private void Square()
        {
        }
        private void Minus()
        {
        }
        private void Plus()
        {
        }
        private void Reciprocal()
        {
        }
        private void Reverse()
        {
        }
        private void Equal()
        {
        }
        private void Zero()
        {
        }
        private void One()
        {
            screen.HandleNum("1");
            ResultText = screen.GetResult();
        }
        private void Two()
        {
        }
        private void Three()
        {
        }
        private void Four()
        {
        }
        private void Five()
        {
        }
        private void Six()
        {
        }
        private void Seven()
        {
        }
        private void Eight()
        {
        }
        private void Nine()
        {
        }
        private string _resultText="0";
        public string ResultText
        {
            get { return _resultText; }
            set { SetPropertyNotify(ref _resultText, value, nameof(ResultText)); }
        }
        private string _expressionText;
        public string ExpressionText
        {
            get { return _expressionText; }
            set { SetPropertyNotify(ref _expressionText, value, nameof(ExpressionText)); }
        }
        private List<string> _history;
        public List<string> History
        {
            get { return _history; }
            set { SetPropertyNotify(ref _history, value, nameof(History)); }
        }
        private List<string> _memory;
        public List<string> Memory
        {
            get { return _memory; }
            set { SetPropertyNotify(ref _memory, value, nameof(Memory)); }
        }






    }
}
