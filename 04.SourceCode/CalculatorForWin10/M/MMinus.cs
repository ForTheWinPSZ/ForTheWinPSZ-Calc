using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class MMinus
    {
        private string resultValue;
        private List<string> memory;
        private double result;
        public MMinus(List<string> memory, string resultValue)
        {
            this.resultValue = resultValue;
            this.memory = memory;
        }
        public List<string> FirstMinus()
        {
            result = Convert.ToDouble(memory[memory.Count - 1]) - Convert.ToDouble(resultValue);
            memory[memory.Count - 1] = Convert.ToString(result);
            return memory;
        }
    }
}
