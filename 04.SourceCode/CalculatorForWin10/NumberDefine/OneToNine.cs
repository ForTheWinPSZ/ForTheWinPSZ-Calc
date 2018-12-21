using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Arithmetic;

namespace NumberDefine
{
    public class OneToNine : Number
    {
        public OneToNine(string content, string resultValue, bool canNumberDef, string expressionValue,string preResult, List<History> history, string lparm) : base(content,resultValue, canNumberDef, expressionValue,preResult,history,lparm)
        {
        }

        public override void InputNum()
        {
            if (!CanNumberDef)
            {
                char[] strs = { '不', '无', '未', '溢' };
                if(PreResult.IndexOfAny(strs) != -1)
                {
                    ExpressionValue = "";
                }

                           
                if (ResultValue!=""&&ExpressionValue!=""&& ExpressionValue.Split(new char[] { ' ' }).Length == 1)
                {                  
                    Lparm = ResultValue;
                    historyString = ExpressionValue;
                    AddHistory();
                    IsUnary = true;
                }
                else
                {
                    IsUnary = false;
                }

                if (!ExpressionValue.EndsWith(" ") && ExpressionValue != "")
                {
                    string[] arr = ExpressionValue.Split(new char[] { ' ' });
                    ExpressionValue = ExpressionValue.Replace(arr[arr.Length - 1], "");
                }
                ResultValue = "";
            }

                if (ResultValue=="0")
                    ResultValue = Content;
                else 
                {
                    ResultValue += Content;
                }
            
        }

    }
}
