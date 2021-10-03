using Calculator_ConsoleApp.Extension;
using CoreBusinessLogic.Interface;
using Serilog;

namespace Calculator_ConsoleApp
{
    public class Calculator
    {
        private readonly IParser _parser;
        private readonly IOperationBuilder _builder;
        public Calculator(IParser expressionParser, IOperationBuilder operationBuilder)
        {
            _parser = expressionParser;
            _builder = operationBuilder;
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
