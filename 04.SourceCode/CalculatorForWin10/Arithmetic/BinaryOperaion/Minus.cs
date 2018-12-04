using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Arithmetic.BinaryOperation
{
    public class Minus : IBinary
    {
        //用来存储一开始resultValue的值
        private string _preResultValue;
        public Minus(string value1, string value2, string value3)
        {
            base._resultValue = value1;
            base._expressionValue = value2;
            base._preResult = value3;
            _preResultValue = _resultValue;
           
            if (_resultValue != ""&&".".Equals(_resultValue.Substring(_resultValue.Length - 1)))
            {
                _resultValue = _resultValue.Substring(0, _resultValue.Length - 1);
            }
            ChangeResultValue();
            ChangeExpression();
        }


        public override void ChangeExpression()
        {
            if (_expressionValue == "")
            {
                _expressionValue = _preResultValue + "-";
                return;
            }
            else
            {
                if (_resultValue == "")
                {
                    Debug.WriteLine("执行换符号操作！");
                    _expressionValue = _expressionValue.Substring(0, _expressionValue.Length - 1) + "-";
                    return;
                }
                _expressionValue = _expressionValue + _preResultValue + "-";
                return;
            }
        }

        public override void ChangeResultValue()
        {
            if (_resultValue == "")
            {
                return;
            }
            //能计算的情况
        
                DataTable table = new DataTable();

                if (_preResult == "")
                {
                    //没有先前暂存值的情况
                    string cul = _expressionValue + _resultValue;
                    if (cul.Contains("x"))
                    {
                        cul = cul.Replace('x', '*');
                    }
                    else if (cul.Contains("÷"))
                    {
                        cul = cul.Replace('÷', '/');
                    }
                    cul = cul.Replace(" ", "");
                    _preResult = table.Compute(cul, "").ToString();
                    return;
                }
                else
                {
                    string symbol = _expressionValue.Substring(_expressionValue.Length - 1);
                    if (symbol.Contains("x"))
                    {
                        symbol = symbol.Replace('x', '*');
                    }
                    else if (symbol.Contains("÷"))
                    {
                        symbol = symbol.Replace('÷', '/');
                    }
                    string cul = _preResult + symbol + _resultValue;
                    cul = cul.Replace(" ", "");
                    _preResult = table.Compute(cul, "").ToString();
                    _resultValue = _preResult;
                    return;
                }
            
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
            return _resultValue;
        }
    }
}
