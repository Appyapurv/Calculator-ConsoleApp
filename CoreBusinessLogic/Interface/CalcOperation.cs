using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Interface
{
    public abstract class CalcOperation<T>
    {
        public abstract T Calculate();
    }
}
