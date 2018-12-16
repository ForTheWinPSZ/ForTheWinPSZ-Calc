﻿using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Text.RegularExpressions;using System.Threading.Tasks;using System.Data;using System.Diagnostics;using Arithmetic.BinaryOperaion;namespace Arithmetic.BinaryOperation{    public class Multiplication : IBinary    {        public Multiplication(string resultValue, string expressionValue, string preResult) : base(resultValue, expressionValue, preResult)        {                    }        public override void Change()        {            if (ExpressionValue == "")            {                PreResult = ResultValue == "" ? PreResult : ResultValue;                ExpressionValue = Tool.MaxContain(PreResult) + " × ";            }            else            {                if (!ExpressionValue.EndsWith(" "))                {
                    string[] arr = ExpressionValue.Split(new char[] { ' ' });                    if (arr.Length < 3)
                    {
                        PreResult = ResultValue;
                        
                    }                                            else                        PreResult = Tool.Compute(PreResult, arr[arr.Length - 2], ResultValue);
                    ExpressionValue = ExpressionValue + " × ";                }                else if (ResultValue == "")                {
                    ExpressionValue = ExpressionValue.Substring(0, ExpressionValue.Length - 3) + " × ";                }                else                {                    string symbol = ExpressionValue.Substring(ExpressionValue.Length - 3).Trim();                    ExpressionValue = ExpressionValue + Tool.MaxContain(ResultValue) + " × ";                    PreResult = Tool.Compute(PreResult, symbol, ResultValue);                }            }        }    }}