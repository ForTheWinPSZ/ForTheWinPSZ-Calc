﻿using Arithmetic.BinaryOperaion;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;namespace Arithmetic{    public class Equal    {        private string resultValue;        private string expressionValue;        private string preResult;        private List<string> history;        private string historyString = "";        private static string lparm;        public Equal(string resultValue, string expressionValue, string preResult, List<string> history, string lparm)        {            this.resultValue = resultValue;            this.expressionValue = expressionValue;            this.preResult = preResult;            this.history = history;            CaculationResult();            AddHistory();        }        public void CaculationResult()        {            if (expressionValue != "")            {                if (!expressionValue.EndsWith(" "))                {                    lparm = resultValue == "" ? preResult : resultValue;                    Debug.WriteLine("lparm:" + lparm);                    historyString = expressionValue;                    string[] arr = expressionValue.Substring(0, expressionValue.Length - 3).Split(new char[] { ' ' });                    if (arr.Length < 3)                    {                        preResult = resultValue;                    }                    else                    {                        preResult = Tool.Compute(preResult, arr[arr.Length - 2], resultValue);                    }                }                else                {                    historyString = expressionValue + (resultValue == "" ? preResult : resultValue);                    string symbol = expressionValue.Substring(expressionValue.Length - 3).Trim();                    preResult = Tool.Compute(preResult, symbol, resultValue == "" ? preResult : resultValue);                }            }            else            {                if (preResult != "")                {                    if (LastHistoryHasBinary())                    {                        string[] arr = history.Last<string>().Split(new char[] { '=' });                        char[] binary = { '+', '-', '×', '÷' };                        int binaryIndex = arr[0].LastIndexOfAny(binary);                        Debug.WriteLine("index:" + binaryIndex + " arr[0]:" + arr[0] + " arr[1]:" + arr[1]);                        string symbol = arr[0].Substring(binaryIndex, 1);                        string lastParam = arr[0].Substring(binaryIndex + 1).Trim();                        Debug.WriteLine("??" + lparm);                        if (lastParam.EndsWith(")"))
                        {
                            lastParam = lparm;
                        }                        historyString = (resultValue == "" ? preResult : resultValue) + " " + symbol + " " + lastParam;                        preResult = Tool.Compute(resultValue == "" ? preResult : resultValue, symbol, lastParam);                    }                    else                    {                        historyString = resultValue == "" ? preResult : resultValue;                        preResult = historyString;                    }                }                else                {                    historyString = resultValue;                    preResult = historyString;                }            }        }        public void AddHistory()        {            if (preResult != "除数不能为零" && preResult != "无效输入" )
            {
                historyString += " = " + preResult;
                history.Add(historyString);
            }        }        public string ReturnExpressionValue()        {            return "";        }        public string ReturnPreResult()        {            return preResult;        }        public string Lparm()        {            return lparm;        }        public List<string> ReturnHistory()        {            return history;        }        public bool LastHistoryHasBinary()        {            string lastHistory = history.Last<string>();            if (lastHistory.Contains("+") || lastHistory.Contains("-") || lastHistory.Contains("×") || lastHistory.Contains("÷"))            {                return true;            }            return false;        }    }}