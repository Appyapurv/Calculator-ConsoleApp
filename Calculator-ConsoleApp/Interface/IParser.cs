using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Interface
{
    public interface IParser
    {
        IList<OperatorEvaluator> Parse(string expression);
    }
}
