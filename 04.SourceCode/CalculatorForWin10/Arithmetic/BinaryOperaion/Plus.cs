﻿using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Text.RegularExpressions;using System.Data;using System.Diagnostics;using Arithmetic.BinaryOperaion;namespace Arithmetic.BinaryOperation{

    public class Plus : IBinary    {

        public Plus(string resultValue, string expressionValue, string preResult)        {            ResultValue = resultValue;            ExpressionValue = expressionValue;            PreResult = preResult;            if (_resultValue.Contains("."))            {
                _resultValue = Convert.ToDouble(_resultValue).ToString();            }
            Change();        }        public override void Change()        {            if (ExpressionValue == "")            {                ExpressionValue = (ResultValue != "" ? ResultValue : PreResult) + " + ";                PreResult = (ResultValue != "" ? ResultValue : PreResult);                ResultValue = "";            }            else            {                if (!ExpressionValue.EndsWith(" "))                {                    ExpressionValue = ExpressionValue + " + ";                    string[] arr = ExpressionValue.Substring(0, ExpressionValue.Length - 3).Split(new char[] { ' ' });                    if (arr.Length < 3)                    {                        PreResult = ResultValue;                    }                    else                    {                        PreResult = Tool.Compute(PreResult, arr[arr.Length - 2], ResultValue);                    }


                }                else if (ResultValue == "")                {                    Debug.WriteLine("执行换符号操作！");                    ExpressionValue = ExpressionValue.Substring(0, ExpressionValue.Length - 3) + " + ";                    ResultValue = PreResult;

                }                else                {                    string symbol = ExpressionValue.Substring(ExpressionValue.Length - 3).Trim();                    ExpressionValue = ExpressionValue + ResultValue + " + ";                    PreResult = Tool.Compute(PreResult, symbol, ResultValue);

                }            }

        }


        public override string ReturnExpressionValue()        {            return ExpressionValue;        }        public override string ReturnPreResult()        {            return PreResult;        }        public override string ReturnResultValue()        {            ResultValue = PreResult;            return ResultValue;        }    }}