using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Arithmetic.BinaryOperation
{
    public class Division : IBinary
    {
        //用来存储一开始resultValue的值
        string preResultValue;
        public Division(string value1,string value2, string value3)
        {
            base.ResultValue = value1;
            base.ExpressionValue = value2;
            base.PreResult = value3;
            
            if (ExpressionValue == "")
                IsComplete = false;
            if (ResultValue != ""&&".".Equals(ResultValue.Substring(ResultValue.Length - 1)))
            {
                ResultValue = ResultValue.Substring(0, ResultValue.Length - 1);
            }
            preResultValue = ResultValue;
            ChangeResultValue();
            ChangeExpression();
        }
        public override void ChangeExpression()
        {
            if (ExpressionValue == "")
            {
                ExpressionValue = preResultValue + "÷";
                return;
            }
            else
            {
                if (ResultValue == "")
                {
                    Debug.WriteLine("执行换符号操作！");
                    ExpressionValue = ExpressionValue.Substring(0, ExpressionValue.Length - 1) + "÷";
                    return;
                }
                ExpressionValue = ExpressionValue + preResultValue + "÷";
                return;
            }
        }

        public override void ChangeResultValue()
        {
            if (ResultValue == "")
            {
                return;
            }
            //能计算的情况
            if (IsComplete)
            {
                DataTable table = new DataTable();

                if (PreResult == "")
                {
                    //没有先前暂存值的情况
                    string cul = ExpressionValue + ResultValue;
                    if (cul.Contains("x"))
                    {
                        cul = cul.Replace('x', '*');
                    }
                    else if (cul.Contains("÷"))
                    {
                        cul = cul.Replace('÷', '/');
                    }
                    cul = cul.Replace(" ", "");
                    PreResult = table.Compute(cul, "").ToString();
                    return;
                }
                else
                {
                    string symbol = ExpressionValue.Substring(ExpressionValue.Length - 1);
                    if (symbol.Contains("×"))
                    {
                        symbol = symbol.Replace('×', '*');
                    }
                    else if (symbol.Contains("÷"))
                    {
                        symbol = symbol.Replace('÷', '/');
                    }
                    string cul = PreResult + symbol + ResultValue;
                    cul = cul.Replace(" ", "");
                    PreResult = table.Compute(cul, "").ToString();
                    ResultValue = PreResult;
                    return;
                }
            }

        }


        public override string ReturnExpressionValue()
        {
            return ExpressionValue;
        }

        public override string ReturnPreResult()
        {
            return PreResult;
        }

        public override string ReturnResultValue()
        {
            return ResultValue;
        }
    }
}
