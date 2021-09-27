using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Interface
{
    public interface IOperationBuilder
    {
        CalcOperation<double> CreateOperation(IList<OperatorEvaluator> symbols, ILogger logger);
    }
}
