using Calculator_ConsoleApp.Builders;
using Calculator_ConsoleApp.Extension;
using CoreBusinessLogic.Helper;
using CoreBusinessLogic.Interface;
using Serilog;

namespace Calculator_ConsoleApp
{
    public class Calculator
    {
        public class Calculators
        {
            private readonly IParser _parser;
            private readonly IOperationBuilder _builder;
            public Calculators()
            {
                _parser = new ExpressionParser();
                _builder = new OperationBuilder();
            }
            /// <summary>
            /// function to evaluate the expression
            /// </summary>
            /// <param name="expression"></param>
            /// <param name="logger"></param>
            /// <returns></returns>
            public double Calculate(string expression, ILogger logger)
            {
                var value = expression.ConvertIntoOperation(logger);

                var operatorList = _parser.Parse(value);
                var result = _builder.CreateOperation(operatorList, logger);
                return result.Calculate();
            }

        }
    }
}
