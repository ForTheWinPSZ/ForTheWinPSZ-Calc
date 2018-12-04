﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.BinaryOperation
{
    public abstract class IBinary
    {
        private string _resultValue;
        private string _expressionValue;
        private string _preResult;
        private string _preUnaryResult;
        private bool _isCompute=true;

        public bool IsComplete { get => _isCompute; set => _isCompute = value; }
        protected string ResultValue { get => _resultValue; set => _resultValue = value; }
        protected string ExpressionValue { get => _expressionValue; set => _expressionValue = value; }
        protected string PreResult { get => _preResult; set => _preResult = value; }
        public string PreUnaryResult { get => _preUnaryResult; set => _preUnaryResult = value; }

        public abstract void ChangeExpression();

        public abstract void ChangeResultValue();
        public abstract string ReturnResultValue();
        public abstract string ReturnExpressionValue();

        public abstract string ReturnPreResult();
    }
}
