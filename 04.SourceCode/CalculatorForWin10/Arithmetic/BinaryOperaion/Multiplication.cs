using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace Arithmetic.BinaryOperation
{
    public class Multiplication : IBinary
    {
        public Multiplication(string resultValue, string expressionValue, string preResult)
        {
            _resultValue = resultValue;
            _expressionValue = expressionValue;
            _preResult = preResult;
            if (_resultValue.EndsWith("."))
            {
                int index = _resultValue.IndexOf(".");
                _resultValue = resultValue.Substring(0, index);
            }
            ChangeResultValue();
            ChangeExpression();

        }

        public override void ChangeExpression()
        {
            if (_expressionValue == "")
            {
                _expressionValue = _resultValue + "x";
            }
            else
            {
                if (_resultValue == "")
                {
                    Debug.WriteLine("执行换符号操作！");
                    _expressionValue = _expressionValue.Substring(0, _expressionValue.Length - 1) + "x";

                }
                else
                {
                    _expressionValue = _expressionValue + _resultValue + "x";
                }
            }
        }

        public override void ChangeResultValue()
        {
            DataTable table = new DataTable();
            string cul;

            if (_preResult == "")
            {
                //没有先前暂存值的情况
                cul = _expressionValue + _resultValue;

            }
            else
            {
                string symbol = _expressionValue.Substring(_expressionValue.Length - 1);
                cul = _preResult + symbol + _resultValue;
            }
            if (cul.Contains("x"))
            {
                cul = cul.Replace('x', '*');
            }
            else if (cul.Contains("÷"))
            {
                cul = cul.Replace('÷', '/');
            }
            cul = cul.Replace(" ", "");
            Debug.WriteLine(cul);
            _preResult = table.Compute(cul, "").ToString();
        }

        public override string ReturnExpressionValue()
        {
            return _expressionValue;
        }

        public override string ReturnPreResult()
        {
            return _preResult;
        }

        public override string ReturnResultValue()
        {
            _resultValue = _preResult;
            return _resultValue;
        }
    }
}
