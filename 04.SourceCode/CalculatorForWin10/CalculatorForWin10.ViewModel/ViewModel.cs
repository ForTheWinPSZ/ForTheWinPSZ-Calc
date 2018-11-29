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
        
        public MainWindowsViewModel()
        {
            btn_point = new NVCommand(AddPoint);
        }

        private void AddPoint()
        {
            Screen screen = new Screen();
            screen.Point1();
            ResultText = screen.getResult();
        }

        private string _resultText;
        public string ResultText
        {
            get { return _resultText; }
            set { SetPropertyNotify(ref _resultText, value, nameof(ResultText)); }
        }


        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }





    }
}
