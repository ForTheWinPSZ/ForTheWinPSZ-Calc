using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class MS
    {
        private string resultValue;
        private List<string> memory;
        public MS(List<string> memory,string resultValue)
        {
            this.resultValue = resultValue;
            this.memory = memory;
        }
        public List<string> AddMemory(string resultValue)
        {
            memory.Add(resultValue);
            return memory;
        }
    }
}
