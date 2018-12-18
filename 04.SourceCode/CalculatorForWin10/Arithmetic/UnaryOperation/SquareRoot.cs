﻿using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;using static System.Convert;using Arithmetic.BinaryOperaion;namespace Arithmetic.UnaryOperation{    public class SquareRoot : IUnary    {        public SquareRoot(string expressionValue, string resultValue, string preResult) : base(expressionValue, resultValue, preResult)        {
            ChangeResultValue();
            ChangeExpression();
        }        public override void ChangeExpression()        {            if (ExpressionValue == "" || ExpressionValue.EndsWith(" "))            {                ExpressionValue += "√(" + Tool.MaxContain(displayText) + ")";            }            else            {                string UnaryExpression = GetUnaryExpression().Trim();                string partExpression = ExpressionValue.Substring(0, binaryIndex);                ExpressionValue = partExpression + "√(" + UnaryExpression + ")";            }        }        public override void ChangeResultValue()        {            ResultValue = Tool1.Calculate("squareroot", displayText = ResultValue == "" ? PreResult : ResultValue);            Debug.WriteLine("根号："+ResultValue);        }            }}