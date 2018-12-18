using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;using static System.Convert;using Arithmetic.BinaryOperaion;namespace Arithmetic.UnaryOperation{    public class Reverse : IUnary    {                public Reverse(string expressionValue, string resultValue, string preResult,bool canNumberDef) : base(expressionValue, resultValue, preResult)        {
            _canNumberDef = canNumberDef;
            ChangeResultValue();
            ChangeExpression();
        }        
        public override void ChangeExpression()        {          
            if (_canNumberDef)
                return;
            if ((ExpressionValue == "" || ExpressionValue.EndsWith(" ")) && (_canNumberDef == false && PreResult != ""))
            {
                Debug.WriteLine("结尾不是单目");
                ExpressionValue += "negate(" + Tool.MaxContain(displayText) + ")";
            }
            else if (ExpressionValue.EndsWith(")"))
            {
                Debug.WriteLine("结尾是单目");
                string UnaryExpression = GetUnaryExpression().Trim();
                string partExpression = ExpressionValue.Substring(0, binaryIndex);
                ExpressionValue = partExpression + "negate(" + UnaryExpression + ")";
            }
        }        public override void ChangeResultValue()        {            ResultValue = Tool1.Calculate("reverse", displayText = ResultValue == "" ? PreResult : ResultValue);        }                public bool ReturnCanNumberDef()
        {
            return _canNumberDef;
        }    }}