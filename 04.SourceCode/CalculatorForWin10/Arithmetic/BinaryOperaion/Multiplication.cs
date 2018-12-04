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
        public Multiplication(string resultValue, string expressionValue, string preResult,string preUnaryResult)
        {
            base.ResultValue = resultValue;
            base.ExpressionValue = expressionValue;
            base.PreResult = preResult;
            base.PreUnaryResult = preUnaryResult;           
            if (ResultValue != ""&&".".Equals(ResultValue.Substring(ResultValue.Length - 1)))
            {
                ResultValue = ResultValue.Substring(0, ResultValue.Length - 1);
            }
           
            ChangeResultValue();
            ChangeExpression();
        }

        public override void ChangeExpression()
        {
            //表达式没有值的时候
            if (ExpressionValue == "")
            { 
                ExpressionValue= ResultValue + " × ";
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
                ExpressionValue= ExpressionValue + ResultValue + " × ";
                return;
            }
        }

        public override void ChangeResultValue()
        {
            DataTable table = new DataTable();
            //初始时候不能计算的时候
            if (ResultValue == "" && PreResult == "")
            {
                return;
            }
            //表达式最后为加减乘除的时候
            if(ExpressionValue.EndsWith(" ")&&ResultValue=="")
            {
                return;
            }
            //第一次存储PreResult的时候
            if (ResultValue != "" && PreResult == "")
            {
                string exps;//拼凑表达式
                if (PreUnaryResult != "")
                {
                    string symbol = ExpressionValue.Trim().Substring(ExpressionValue.Length - 1);
                    symbol = ForCompute(symbol);
                     exps= PreUnaryResult + symbol + ResultValue;                    
                }
                else
                {
                    exps = ForCompute(ExpressionValue) + ResultValue;
                }
                PreResult = table.Compute(exps, "").ToString();
                return;
            }
            if (ResultValue == "" && PreResult == "" && PreUnaryResult == "")
            {
                char[] binary = { '+', '-', '×', '÷' };
                int index = ExpressionValue.LastIndexOfAny(binary);
                string exps = ExpressionValue.Substring(0, index + 1) + PreUnaryResult;
                exps = ForCompute(exps);
                PreResult = table.Compute(exps, "").ToString();
                return;
            }
            //多行运算的时候
            if (PreResult != null)
            {
                //最后不是单目运算的时候
                if(ExpressionValue.EndsWith(" "))
                {
                    string symbol = ExpressionValue.Trim().Substring(ExpressionValue.Trim().Length - 1);
                    string cul = PreResult + symbol + ResultValue;
                    cul = ForCompute(cul);
                    PreResult = table.Compute(cul, "").ToString();
                    return;
                }
                //最后是单目运算的时候
                else
                {
                    char[] binary = { '+', '-', '×', '÷' };
                    int index = ExpressionValue.LastIndexOfAny(binary);
                    string symbol = ExpressionValue.Substring(index, index + 1);
                    string cul = PreResult + symbol + ResultValue;
                    cul = ForCompute(cul);
                    PreResult = table.Compute(cul, "").ToString();
                    return;
                }
                
            }

        }

        //去掉空格，将X和÷替换为可以计算的
        private static string ForCompute(string expression)
        {
            expression = expression.Trim().Replace(" ","");
            if (expression.Contains("×"))
            {
                expression = expression.Replace('×', '*');
            }
            else if (expression.Contains("÷"))
            {
                expression = expression.Replace('÷', '/');
            }
            return expression;
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
