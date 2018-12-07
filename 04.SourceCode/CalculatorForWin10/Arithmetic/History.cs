using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    public class History
    {
        private string _expression;
        private string _result;

        public History(string expression ,string result)
        {
            Expression = expression;
            Result = result;
        }
        public string Expression { get => _expression; set => _expression = value; }
        public string Result { get => _result; set => _result = value; }
        public override string ToString()
        {
            return _expression + _result;
        }
    }
}
