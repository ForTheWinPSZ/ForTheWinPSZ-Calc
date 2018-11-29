using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M;

namespace CalculatorForWin10.ViewModel
{
    public class Screen
    {
        private string resultValue;

        public string getResult()
        {
            return resultValue;
        }

        public void Point1()
        {
             resultValue  =  new Point().AddBtn_point();
        }

    }
}
