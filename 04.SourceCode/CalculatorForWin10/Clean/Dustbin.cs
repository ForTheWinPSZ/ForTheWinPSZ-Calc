using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class Dustbin
    {
        private List<string> history;

        public Dustbin(List<string> history)
        {
            this.history = history;
        }

        public List<string> ClearHistory()
        {
            return history;
        }
    }
}
