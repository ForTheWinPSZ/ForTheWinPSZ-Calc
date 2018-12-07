﻿using Arithmetic.BinaryOperaion;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;namespace Arithmetic{    public class Equal    {        private string resultValue;        private string expressionValue;        private string preResult;        private List<History> history;        private string historyString = "";        private static string lparm;        private string _lhistory;
        private string lastHistory;        public Equal(string resultValue, string expressionValue, string preResult, List<History> history, string lparm, string lhistory)        {            this.resultValue = resultValue;            this.expressionValue = expressionValue;            this.preResult = preResult;            this.history = history;            this._lhistory = lhistory;            CaculationResult();            AddHistory();        }        public void CaculationResult()        {            if (expressionValue != "")            {                if (!expressionValue.EndsWith(" "))                {                    lparm = resultValue == "" ? preResult : resultValue;                    Debug.WriteLine("lparm:" + lparm);                    historyString = expressionValue;                    string[] arr = expressionValue.Substring(0, expressionValue.Length - 3).Split(new char[] { ' ' });                    if (arr.Length < 3)                    {                        preResult = resultValue;                    }                    else                    {                        preResult = Tool.Compute(preResult, arr[arr.Length - 2], resultValue);                    }                }                else                {                    if (resultValue.Contains("."))
                    {
                        resultValue = Convert.ToDouble(resultValue).ToString();
                    }                    string symbol = expressionValue.Substring(expressionValue.Length - 3).Trim();                    if ((resultValue == "" && preResult == "0" && symbol == "÷") ||(resultValue == "0" && preResult == "0" && symbol == "÷"))
                    {
                        preResult = "结果未定义";
                    }
                    else
                    {
                        historyString = expressionValue + (resultValue == "" ? preResult : resultValue);
                        
                        preResult = Tool.Compute(preResult, symbol, resultValue == "" ? preResult : resultValue);
                    }                                   }            }            else            {                if (resultValue.Contains("."))
                {
                    resultValue = Convert.ToDouble(resultValue).ToString();
                }                if (preResult != "")                {                    if (LastHistoryHasBinary())                    {                        string[] arr = lastHistory.Split(new char[] { '=' });                        char[] binary = { '+', '-', '×', '÷' };                        int binaryIndex = arr[0].LastIndexOfAny(binary);                        Debug.WriteLine("index:" + binaryIndex + " arr[0]:" + arr[0] + " arr[1]:" + arr[1]);                        string symbol = arr[0].Substring(binaryIndex, 1);                        string lastParam = arr[0].Substring(binaryIndex + 1).Trim();                        Debug.WriteLine("??" + lparm);                        if (lastParam.EndsWith(")"))
                        {
                            lastParam = lparm;
                        }                        historyString = (resultValue == "" ? preResult : resultValue) + " " + symbol + " " + lastParam;                        preResult = Tool.Compute(resultValue == "" ? preResult : resultValue, symbol, lastParam);                    }                    else                    {                        historyString = resultValue == "" ? preResult : resultValue;                        preResult = historyString;                    }                }                else                {                    historyString = resultValue;                    preResult = historyString;                }            }        }        public void AddHistory()        {            if (preResult != "除数不能为零" && preResult != "无效输入" && preResult != "结果未定义")
            {
                History his = new History(historyString + " = ", preResult);
                history.Add(his);
            }        }        public string ReturnExpressionValue()        {            return "";        }        public string ReturnPreResult()        {            return preResult;        }        public string Lparm()        {            return lparm;        }        public List<History> ReturnHistory()        {            return history;        }        public bool LastHistoryHasBinary()        {
            if (history.Count == 0)            {                lastHistory = _lhistory;


            }
            else
            {
                lastHistory = history.Last<History>().ToString();
            }                        if (lastHistory.Contains("+") || lastHistory.Contains("-") || lastHistory.Contains("×") || lastHistory.Contains("÷"))            {                return true;            }            return false;        }    }}