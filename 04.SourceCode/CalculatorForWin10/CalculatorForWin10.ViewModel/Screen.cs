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
        private string content;

        public string getResult()
        {
            return content;
        }

        public void Point1()
        {
             content  =  new Point().AddBtn_point();
        }

    }
}
