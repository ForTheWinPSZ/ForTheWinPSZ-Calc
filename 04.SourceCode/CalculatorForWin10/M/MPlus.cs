using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class MPlus
    {
        private string resultValue;
        private List<string> memory;
        private double result;
        public MPlus(List<string> memory, string resultValue)
        {
            this.resultValue = resultValue;
            this.memory = memory;
        }
        public List<string> FirstPlus()
        {
            if (memory.Count == 0)
            {
                memory.Add(resultValue);
            }
            else
            {
                result = Convert.ToDouble(memory[memory.Count - 1]) + Convert.ToDouble(resultValue);
                memory[memory.Count - 1] = Convert.ToString(result);
            }
            return memory;
        }
    }
}
