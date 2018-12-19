﻿using Arithmetic.BinaryOperaion;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;namespace Arithmetic{    public class Equal    {        private string resultValue;        private string expressionValue;        private string preResult;        private List<History> history;        private string historyString = "";        private static string lparm;        private string _lhistory;
        private string lastHistory;        public Equal(string resultValue, string expressionValue, string preResult, List<History> history, string lparm, string lhistory)        {            this.resultValue = resultValue;            this.expressionValue = expressionValue;            this.preResult = preResult;            this.history = history;            _lhistory = lhistory;            CaculationResult();            AddHistory();        }        public void CaculationResult()        {                        if (expressionValue != "")            {                if (!expressionValue.EndsWith(" "))                {                                       if (expressionValue.Split(new char[] { ' ' }).Length==1 && LastHistoryHasBinary())
                    {
                        string[] arr1 = lastHistory.Split(new char[] { ' ' });
                        string sym = arr1[arr1.Length - 4].Trim();
                        preResult= Tool.Compute(resultValue,sym, lparm);
                        historyString = expressionValue + " " + sym + " "+Tool.MaxContain(lparm);
                    }
                    else
                    {
                        lparm = resultValue == "" ? preResult : resultValue;
                        historyString = expressionValue;
                        string[] arr = expressionValue.Split(new char[] { ' ' });
                        if (arr.Length < 3)
                            preResult = resultValue;
                        else
                            preResult = Tool.Compute(preResult, arr[arr.Length - 2], resultValue);
                    }                                  }                else                {                    if (resultValue.Contains("."))
                        resultValue = Convert.ToDecimal(resultValue).ToString();                    string symbol = expressionValue.Substring(expressionValue.Length - 3).Trim();                    if ((resultValue == "" && preResult == "0" && symbol == "÷") || (resultValue == "0" && preResult == "0" && symbol == "÷"))
                        preResult = "结果未定义";
                    else
                    {
                        lparm = resultValue == "" ? preResult : resultValue;
                        historyString = expressionValue + (resultValue == "" ? Tool.MaxContain(preResult) : Tool.MaxContain(resultValue));
                        preResult = Tool.Compute(preResult, symbol, resultValue == "" ? preResult : resultValue);

                    }
                }            }            else            {                                if (preResult != "")                {                    if (LastHistoryHasBinary())                    {                        string[] arr = lastHistory.Split(new char[] { ' ' });                                                                      string symbol = arr[arr.Length - 4].Trim();                        string lastParam = arr[arr.Length - 3].Trim();
                        if (lastParam.EndsWith(")"))
                            lastParam = lparm;                                        historyString = (resultValue == "" ? Tool.MaxContain(preResult): Tool.MaxContain(resultValue)) + " " + symbol + " " + Tool.MaxContain(lastParam);                        preResult =Tool.Compute(resultValue == "" ? preResult : resultValue, symbol, lastParam);                    }                    else                    {                        historyString = resultValue == "" ? Tool.MaxContain(preResult) : Tool.MaxContain(resultValue);                        preResult = historyString;                    }                }                else                {                    historyString = resultValue;                    preResult = historyString;                }            }        }        public void AddHistory()        {            char[] strs = { '不', '无', '未', '溢' };            if (resultValue.IndexOfAny(strs) == -1)
            {
                History his = new History(historyString + " = ",Tool.MaxContain(preResult));
                history.Add(his);
            }        }        public string ReturnExpressionValue()        {            return "";        }        public string ReturnPreResult()        {            return preResult;        }        public string Lparm()        {            return lparm;        }        public List<History> ReturnHistory()        {            return history;        }        public bool LastHistoryHasBinary()        {
            if (history.Count == 0)            {                lastHistory = _lhistory;
            }
            else
            {
                lastHistory = history.Last<History>().ToString();
            }            ;
            if (lastHistory.Split(new char[] { ' ' }).Length>=5)            {                return true;            }            return false;        }    }}