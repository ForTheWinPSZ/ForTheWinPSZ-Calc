using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class MC
    {
        private List<string> memory;
        public MC(List<string> memory)
        {
            this.memory = memory;
        }
        public List<string> CleanAll()
        {
            memory.Clear();
            return memory;
        }
    }
}
