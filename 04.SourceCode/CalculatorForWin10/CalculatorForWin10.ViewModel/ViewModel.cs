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
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => Btn_mc; }
        private readonly NVCommand Btn_mc;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }
        private readonly NVCommand btn_point;
        public NVCommand Btn_point { get => btn_point; }

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
