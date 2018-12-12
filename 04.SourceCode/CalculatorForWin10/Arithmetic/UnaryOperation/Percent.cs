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
        protected int binaryIndex;
        protected string displayText = "";
        private string LastHistory;
        protected string ResultValue { get => _resultValue; set => _resultValue = value; }
        protected string ExpressionValue { get => _expressionValue; set => _expressionValue = value; }
        protected string PreResult { get => _preResult; set => _preResult = value; }        public Percent(string expressionValue, string resultValue, string preResult,string lHistroy)        {
            this.ExpressionValue = expressionValue;            this.ResultValue = resultValue;            this.PreResult = preResult;
            this.LastHistory = lHistroy;
            if (ResultValue.Contains("."))            {                ResultValue = Convert.ToDecimal(ResultValue).ToString();            }
            ChangeResultValue();
            ChangeExpression();        }        public  void ChangeExpression()        {            if (ExpressionValue == "" || ExpressionValue.EndsWith(" "))            {                ExpressionValue += ResultValue;            }            else            {                string UnaryExpression = GetUnaryExpression().Trim();                string partExpression = ExpressionValue.Substring(0, binaryIndex);                ExpressionValue = partExpression +Tool.MaxContain(displayText);            }        }        public  void ChangeResultValue()        {                        string[] strs = ExpressionValue.Split(new char[] { ' ' });            char[] binary = {  '×', '÷' };
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

    }
}
