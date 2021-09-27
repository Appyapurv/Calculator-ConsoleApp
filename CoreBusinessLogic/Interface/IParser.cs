using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Interface
{
    public interface IParser
    {
        IList<OperatorEvaluator> Parse(string expression);
    }
}
