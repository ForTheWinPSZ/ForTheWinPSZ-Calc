using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;
using System.Diagnostics;

namespace Arithmetic.BinaryOperation
{

    public class Plus : IBinary
    {
        //用来存储一开始resultValue的值
        string preResultValue;
        public Plus(string value1,string value2,string value3)
        {
            base.resultValue = value1;
            base.expressionValue = value2;
            base.preResult = value3;
            preResultValue = resultValue;
            if (expressionValue == "")
                IsComplete = false;

            if (resultValue!=""&&".".Equals(resultValue.Substring(resultValue.Length - 1)))
            {
                resultValue = resultValue.Substring(0, resultValue.Length - 1);
            }
            ChangeResultValue();
            ChangeExpression();
        }
        public override void ChangeExpression()
        {
            if (expressionValue == "")
            {
                expressionValue = preResultValue + "+";
                return;
            }
            else
            {
                if (resultValue == "")
                {
                    Debug.WriteLine("执行换符号操作！");
                    expressionValue = expressionValue.Substring(0, expressionValue.Length - 1) + "+";
                    return;
                }
                expressionValue = expressionValue + preResultValue + "+";
                return;
            }
        }

        public override void ChangeResultValue()
        {
            if (resultValue == "")
            {
                return;
            }
            //能计算的情况
            if (IsComplete)
            {
                DataTable table = new DataTable();

                if (preResult == "")
                {
                    //没有先前暂存值的情况
                    string cul = expressionValue + resultValue;
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
                    preResult = table.Compute(cul, "").ToString();
                    return;
                }
                else
                {
                    string symbol = expressionValue.Substring(expressionValue.Length - 1);
                    if (symbol.Contains("x"))
                    {
                        symbol = symbol.Replace('x', '*');
                    }
                    else if (symbol.Contains("÷"))
                    {
                        symbol = symbol.Replace('÷', '/');
                    }
                    string cul = preResult + symbol + resultValue;
                    cul=cul.Replace(" ","");
                    preResult = table.Compute(cul, "").ToString();
                    resultValue = preResult;
                    return;
                }
            }

        }

        public override string ReturnExpressionValue()
        {
            return expressionValue;
        }

        public override string ReturnPreResult()
        {
            return preResult;
        }

        public override string ReturnResultValue()
        {
            return resultValue;
        }
    }
}
