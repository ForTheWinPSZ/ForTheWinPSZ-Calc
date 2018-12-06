using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class MS
    {
        private string resultValue;
        private List<string> memory;
        private string preResult;
        public MS(List<string> memory,string resultValue,string preResult)
        {
            this.resultValue = resultValue;
            this.preResult = preResult;
            this.memory = memory;
        }
        public List<string> AddMemory(string resultValue)
        {
            if (resultValue=="")
            {
                resultValue = preResult;
            }
            memory.Add(resultValue);
            return memory;
        }
    }
}
