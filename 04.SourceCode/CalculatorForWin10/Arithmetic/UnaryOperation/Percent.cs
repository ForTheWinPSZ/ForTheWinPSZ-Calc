using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using System.Diagnostics;
using Arithmetic.BinaryOperaion;

namespace Arithmetic.UnaryOperation
{
    public class Percent
    {        private string _resultValue;
        private string _expressionValue;
        private string _preResult;
        private List<History> history;
        private string lparm;
        private  bool isUnary = false;
        private string historyString="";
        protected int binaryIndex;
        protected string displayText = "";
        private string LastHistory;
        protected string ResultValue { get => _resultValue; set => _resultValue = value; }
        protected string ExpressionValue { get => _expressionValue; set => _expressionValue = value; }
        protected string PreResult { get => _preResult; set => _preResult = value; }
        public string Lparm { get => lparm; set => lparm = value; }
        public List<History> History { get => history; set => history = value; }
        public bool IsUnary { get => isUnary; set => isUnary = value; }

        public Percent(string expressionValue, string resultValue, string preResult,string lHistroy,List<History>  history,string lparm)        {
            this.ExpressionValue = expressionValue;            this.ResultValue = resultValue;            this.PreResult = preResult;
            this.LastHistory = lHistroy;
            this.History = history;
            this.Lparm = lparm;
            if (ResultValue.Contains("."))            {                ResultValue = Convert.ToDecimal(ResultValue).ToString();            }
            ChangeResultValue();
            ChangeExpression();        }        public  void ChangeExpression()        {            if (ExpressionValue == "" || ExpressionValue.EndsWith(" "))            {                ExpressionValue += Tool.MaxContain(ResultValue);            }            else            {                string UnaryExpression = GetUnaryExpression().Trim();                if (ExpressionValue.Trim().Equals(UnaryExpression.Trim()))                    ExpressionValue = "0";                else
                {
                    string partExpression = ExpressionValue.Substring(0, binaryIndex);
                    ExpressionValue = partExpression + Tool.MaxContain(displayText);
                }                            }        }        public  void ChangeResultValue()        {
            char[] binary1 = { '+', '-', '×', '÷' };
            if ((ResultValue != "" && ExpressionValue != "" && ExpressionValue.LastIndexOfAny(binary1) == -1)||ExpressionValue.Equals("0"))
            {
                Lparm = ResultValue;
                historyString = ExpressionValue;
                AddHistory();
                IsUnary = true;
            }
            else
            {
                IsUnary = false;
            }            string[] strs = ExpressionValue.Split(new char[] { ' ' });            char[] binary = {  '×', '÷' };
            int index = ExpressionValue.LastIndexOfAny(binary);
            if (index != -1)
            {
                if (strs[strs.Length - 1].LastIndexOfAny(binary) != -1 || strs[strs.Length - 2].LastIndexOfAny(binary) != -1)
                    ResultValue = displayText = ResultValue == "" ? (ToDecimal(PreResult) / 100).ToString() : (ToDecimal(ResultValue) / 100).ToString();
                else
                    ResultValue = Calculate(displayText = ResultValue == "" ? PreResult : ResultValue);
            }
            else
            {

                if (PreResult!=""&& LastHistory != "")
                {
                    index = LastHistory.LastIndexOfAny(binary);
                    if (index != -1)
                    {
                        string[] strs2 = LastHistory.Split(new char[] { ' ' });
                        if(strs2[strs2.Length-4].LastIndexOfAny(binary) != -1)
                        {
                            ResultValue = displayText = ResultValue == "" ? (ToDecimal(PreResult) / 100).ToString() : (ToDecimal(ResultValue) / 100).ToString();
                            return;
                        }
                    }

                }
                ResultValue = Calculate(displayText = ResultValue == "" ? PreResult : ResultValue);
            }                        }        public string Calculate(string param)        {
            if (PreResult == "")
                PreResult = "0";
            return ((ToDecimal(PreResult) * ToDecimal(param) / 100)).ToString();        }

        public string GetUnaryExpression()        {            binaryIndex = ExpressionValue.LastIndexOf(" ") + 1;            return ExpressionValue.Substring(binaryIndex);        }
        public string ReturnExpressionValue()        {            return ExpressionValue;        }
        public string ReturnResultValue()        {            return ResultValue;        }
        public List<History> ReturnHistory()        {            return History;        }
        public void AddHistory()        {            if (ResultValue != "除数不能为零" && ResultValue != "无效输入" && ResultValue != "结果未定义")
            {
                History his = new History(historyString + " = ", "0");
                History.Add(his);
            }        }
    }
}
