using System;
using System.Collections.Generic;
using System.Text;

namespace M
{
    public class MemoryDustbin
    {
        private List<string> historyList;



        public MemoryDustbin(List<string> list)

        {

            this.historyList = list;

        }



        public List<string> Clear()

        {

            historyList.Clear();

            return historyList;

        }
    }
}
