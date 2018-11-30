using Infrastructure;
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
        public MainWindowsViewModel()
        {
            btn_point = new NVCommand(AddPoint);
            btn_0 = new NVCommand(AddBtn_0);
            btn_1 = new NVCommand(AddBtn_1);
            btn_2 = new NVCommand(AddBtn_2);
            btn_3 = new NVCommand(AddBtn_3);
            btn_4 = new NVCommand(AddBtn_4);
            btn_5 = new NVCommand(AddBtn_5);
            btn_6 = new NVCommand(AddBtn_6);
            btn_7 = new NVCommand(AddBtn_7);
            btn_8 = new NVCommand(AddBtn_8);
            btn_9 = new NVCommand(AddBtn_9);
        }

        private void AddPoint()
        {            
            screen.Point();
        }

        private void AddBtn_0()
        {
            screen.Num("0");
            ResultText = screen.GetResult();
        }
        private void AddBtn_1()
        {
            screen.Num("1");
            ResultText = screen.GetResult();
        }
        private void AddBtn_2()
        {
            screen.Num("2");
            ResultText = screen.GetResult();
        }
        private void AddBtn_3()
        {
            screen.Num("3");
            ResultText = screen.GetResult();
        }
        private void AddBtn_4()
        {
            screen.Num("4");
            ResultText = screen.GetResult();
        }
        private void AddBtn_5()
        {
            screen.Num("5");
            ResultText = screen.GetResult();
        }
        private void AddBtn_6()
        {
            screen.Num("6");
            ResultText = screen.GetResult();
        }
        private void AddBtn_7()
        {
            screen.Num("7");
            ResultText = screen.GetResult();
        }
        private void AddBtn_8()
        {
            screen.Num("8");
            ResultText = screen.GetResult();
        }
        private void AddBtn_9()
        {
            screen.Num("9");
            ResultText = screen.GetResult();
        }


        private string _resultText;
        public string ResultText
        {
            get { return _resultText; }
            set { SetPropertyNotify(ref _resultText, value, nameof(ResultText)); }
        }


        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }

        public NVCommand Btn_1 => btn_1;

        public NVCommand Btn_0 => btn_0;

        public NVCommand Btn_2 => btn_2;

        public NVCommand Btn_3 => btn_3;

        public NVCommand Btn_4 => btn_4;

        public NVCommand Btn_5 => btn_5;

        public NVCommand Btn_6 => btn_6;

        public NVCommand Btn_7 => btn_7;

        public NVCommand Btn_8 => btn_8;

        public NVCommand Btn_9 => btn_9;

        private readonly NVCommand btn_0;
        private readonly NVCommand btn_1;
        private readonly NVCommand btn_2;
        private readonly NVCommand btn_3;
        private readonly NVCommand btn_4;
        private readonly NVCommand btn_5;
        private readonly NVCommand btn_6;
        private readonly NVCommand btn_7;
        private readonly NVCommand btn_8;
        private readonly NVCommand btn_9;

    }
}
