using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForWin10.ViewModel
{
    public class Screen
    {
        private string resultValue;
        private string expressionValue;
        private List<string> memory;
        private List<string> history;
        
        public string getResult()
        {
            return resultValue;
        }

        public void Point1()
        {
            resultValue =  new Point().AddBtn_point(resultValue);
        }

    }
}
