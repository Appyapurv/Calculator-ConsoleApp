using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Interface
{
    public interface IOperationBuilder
    {
        CalcOperation CreateOperation(IList<OperatorEvaluator> symbols);
    }
}
