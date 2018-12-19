using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Number
{
    public class OneToNine
    {
        private string resultValue;

        public OneToNine(string resultValue)
        {
            this.resultValue = resultValue;
        }

        public string InputNumber(string num)
        {
            Debug.WriteLine("输出栏：" + resultValue + "num值：" +  num);
            resultValue += num;
            Debug.WriteLine("处理后输出栏：" + resultValue );
            return resultValue;
        }
    }
}
