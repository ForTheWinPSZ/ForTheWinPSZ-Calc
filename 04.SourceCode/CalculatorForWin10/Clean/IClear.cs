using System;
using System.Collections.Generic;
using System.Text;

namespace Clean
{
    public interface IClear
    {
        void ClearResultValue();
        string ReturnResultValue();
        string ReturnExpressionValue();
        string ReturnPreResult();
    }
}
