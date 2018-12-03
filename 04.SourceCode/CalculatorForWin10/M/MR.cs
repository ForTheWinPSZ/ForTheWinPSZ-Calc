using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class MR
    {
        private List<string> memory;
        private string resultValue;
        public MR(List<string> memory, string resultValue)
        {
            this.resultValue = resultValue;
            this.memory = memory;
        }
        public string ReUse()
        {
            resultValue = memory[memory.Count-1];
            return resultValue;
        }
    }
}
