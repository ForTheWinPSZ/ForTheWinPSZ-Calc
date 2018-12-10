using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDefine
{
    public abstract class Number
    {
        private string resultValue;
        private bool canNumberDef;
        private string expressionValue;
        private string content;
        public string ResultValue { get => resultValue; set => resultValue = value; }
        public bool CanNumberDef { get => canNumberDef; set => canNumberDef = value; }
        public string ExpressionValue { get => expressionValue; set => expressionValue = value; }
        public string Content { get => content; set => content = value; }

        public Number(string content, string resultValue, bool canNumberDef, string expressionValue)
        {
            ResultValue = resultValue;
            CanNumberDef = canNumberDef;
            ExpressionValue = expressionValue;
            Content = content;
            InputNum();
        }
        public abstract void InputNum();
        public string ReturnResultValue()
        {
            return Filter.returnNum(ResultValue);
        }
        public string ReturnExpressionValue()
        {
            return ExpressionValue;
        }
        public bool ReturnCanNumberDef()
        {
            return true;
        }
    }
}
