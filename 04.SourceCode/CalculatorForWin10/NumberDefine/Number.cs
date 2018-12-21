using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic;
using Arithmetic.BinaryOperaion;

namespace NumberDefine
{
    public abstract class Number
    {
        private string resultValue;
        private bool canNumberDef;
        private string expressionValue;
        private string content;
        private string preResult;
        private List<History> history;
        private string lparm;
        private bool isUnary=false;

        protected string historyString = "";
        public string ResultValue { get => resultValue; set => resultValue = value; }
        public bool CanNumberDef { get => canNumberDef; set => canNumberDef = value; }
        public string ExpressionValue { get => expressionValue; set => expressionValue = value; }
        public string Content { get => content; set => content = value; }
        public string PreResult { get => preResult; set => preResult = value; }
        public List<History> History { get => history; set => history = value; }
        public string Lparm { get => lparm; set => lparm = value; }
        public bool IsUnary { get => isUnary; set => isUnary = value; }

        public Number(string content, string resultValue, bool canNumberDef, string expressionValue,string preResult, List<History> history, string lparm)
        {
            ResultValue = resultValue;
            CanNumberDef = canNumberDef;
            ExpressionValue = expressionValue;
            Content = content;
            PreResult = preResult;
            History = history;
            Lparm = lparm;
            InputNum();
        }
        public abstract void InputNum();
        public string ReturnResultValue()
        {
            return Filter.ReturnNum(ResultValue);
        }
        public string ReturnExpressionValue()
        {
            return ExpressionValue;
        }
        public bool ReturnCanNumberDef()
        {
            return true;
        }
                public List<History> ReturnHistory()        {            return History;        }
        public void AddHistory()        {            char[] strs = { '不', '无', '未', '溢' };            if (resultValue.IndexOfAny(strs) == -1)
            {
                History his = new History(historyString + " = ",HistoryDisplayTool.AddComma(HistoryDisplayTool.MaxContain(resultValue)));
                history.Add(his);
            }        }
    }
}
