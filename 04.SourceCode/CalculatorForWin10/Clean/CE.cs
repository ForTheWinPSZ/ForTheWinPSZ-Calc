using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public class CE : Clear
    {
        private string resultValue;

        public CE(string resultValue)
        {
            this.resultValue = resultValue;
        }

        public string ClearResultValue()
        {
            return "";
        }
    }
}
