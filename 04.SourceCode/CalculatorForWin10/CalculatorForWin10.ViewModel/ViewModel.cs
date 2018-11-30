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
        public MainWindowsViewModel()
        {
            btn_point = new NVCommand(AddBtn_point);
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

        private string _resultText = "0";
        public string ResultText
        {
            get { return _resultText; }
            set { SetPropertyNotify(ref _resultText, value, nameof(ResultText)); }
        }

        Screen screen = new Screen();

        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_0;
        public NVCommand Btn_0 { get => btn_0; }
        private readonly NVCommand btn_1;
        public NVCommand Btn_1 { get => btn_1; }
        private readonly NVCommand btn_2;
        public NVCommand Btn_2 { get => btn_2; }
        private readonly NVCommand btn_3;
        public NVCommand Btn_3 { get => btn_3; }
        private readonly NVCommand btn_4;
        public NVCommand Btn_4 { get => btn_4; }
        private readonly NVCommand btn_5;
        public NVCommand Btn_5 { get => btn_5; }
        private readonly NVCommand btn_6;
        public NVCommand Btn_6 { get => btn_6; }
        private readonly NVCommand btn_7;
        public NVCommand Btn_7 { get => btn_7; }
        private readonly NVCommand btn_8;
        public NVCommand Btn_8 { get => btn_8; }
        private readonly NVCommand btn_9;
        public NVCommand Btn_9 { get => btn_9; }


        private void AddBtn_point()
        {
            
        }
        private void AddBtn_0()
        {
           
        }
        private void AddBtn_1()
        {
            screen.InputOneToNine("1");
            ResultText = screen.ResultValue;
        }
        private void AddBtn_2()
        {
           
        }
        private void AddBtn_3()
        {
            
        }
        private void AddBtn_4()
        {
           
        }
        private void AddBtn_5()
        {
           
        }
        private void AddBtn_6()
        {
            
        }
        private void AddBtn_7()
        {
            
            
        }
        private void AddBtn_8()
        {
            
        }
        private void AddBtn_9()
        {
            
        }


    }
}
