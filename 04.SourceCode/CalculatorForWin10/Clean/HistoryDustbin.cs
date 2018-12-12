using System;
using Arithmetic;
using System.Collections.Generic;

using System.Text;
namespace Clean

{

    public class HistoryDustbin

    {

        private List<History> historyList;



        public HistoryDustbin(List<History> list)

        {

            this.historyList = list;

        }



        public List<History> Clear()

        {

            historyList.Clear();

            return historyList;

        }

    }

}