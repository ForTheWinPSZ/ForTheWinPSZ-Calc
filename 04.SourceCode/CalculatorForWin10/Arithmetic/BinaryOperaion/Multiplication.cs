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
        //用来存储一开始resultValue的值
        string _preResultValue;
        public Multiplication(string resultValue, string expressionValue, string preResult)
        {
            base.ResultValue = resultValue;
            base.ExpressionValue = expressionValue;
            base.PreResult = preResult;
            
            if (ExpressionValue == "")
                IsComplete = false;
            if (ResultValue != ""&&".".Equals(ResultValue.Substring(ResultValue.Length - 1)))
            {
                ResultValue = ResultValue.Substring(0, ResultValue.Length - 1);
            }
            _preResultValue = ResultValue;
            ChangeResultValue();
            ChangeExpression();
        }

        public override void ChangeExpression()
        {
            //表达式没有值的时候
            if (ExpressionValue == "")
            { 
                ExpressionValue= _preResultValue + " × ";
                return;
            }
            else
            {
                //表达式有值且最后是单目运算的时候
                if (ExpressionValue.Trim().EndsWith(")"))
                {
                    ExpressionValue = ExpressionValue + " × ";
                    return;
                }
                
                //表达式有值且非数字定义且最后非单目运算的时候           
                if (ResultValue==""&&!ExpressionValue.Trim().EndsWith(")"))
                {
                    Debug.WriteLine("执行换符号操作！");
                    ExpressionValue= ExpressionValue.Substring(0, ExpressionValue.Length - 1) + " × ";
                    return;
                }
                //表达式有值且是数字定义的时候
                ExpressionValue= ExpressionValue + _preResultValue + " × ";
                return;
            }
        }

        public override void ChangeResultValue()
        {
            //不能计算
            if (ResultValue == "")
            {
                return;
            }
            //能计算的情况
            if (IsComplete)                         
            {                
                DataTable table = new DataTable();

                if (PreResult=="")
                {
                    //没有先前暂存值的情况
                    string cul = ExpressionValue+ResultValue;
                    if (cul.Contains("×"))
                    {
                        cul=cul.Replace('×','*');
                    }else if (cul.Contains("÷"))
                    {
                        cul = cul.Replace('÷', '/');
                    }
                    cul = cul.Replace(" ", "");
                    PreResult = table.Compute(cul,"").ToString();                   
                    return;
                }
                else
                {
                    //有暂存值且结尾是单目运算的情况
                    string exps = ExpressionValue.Trim();
                    if (exps.Substring(exps.Length - 1) == ")")
                    {
                        char[] binary = { '+', '-', '×', '÷' };
                        int index = ExpressionValue.LastIndexOfAny(binary);
                        if (index == -1)
                            return;
                        else
                        {
                            exps = exps.Substring(0, index + 1)+PreResult;
                            exps=exps.Replace(" ", "");
                            PreResult= table.Compute(exps, "").ToString();
                            return;
                        }
                    }

                   
                    string symbol = ExpressionValue.Trim().Substring(ExpressionValue.Trim().Length - 1);
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
                    ResultValue= PreResult;
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
