using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using System.Diagnostics;using static System.Convert;using Arithmetic.BinaryOperaion;namespace Arithmetic.UnaryOperation{    public class Reverse : IUnary    {        private bool _canNumberDef;        public Reverse(string expressionValue, string resultValue, string preResult,bool canNumberDef) : base(expressionValue, resultValue, preResult)        {
            this._canNumberDef = canNumberDef;
        }        
        public override void ChangeExpression()        {
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