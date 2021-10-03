using Calculator_ConsoleApp.Extension;
using Calculator_ConsoleApp.Utilities;
using CoreBusinessLogic.Interface;
using CoreBusinessLogic.Models.Enums;
using CoreBusinessLogic.Operation;
using CoreBusinessLogic.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator_ConsoleApp.Builders
{
    public class OperationBuilder : IOperationBuilder
    {
        public CalcOperation<double> CreateOperation(IList<OperatorEvaluator> operatorList, ILogger logger)
        {
            var result = AddSubtractCalc(operatorList, 0, out _, logger);
            return result;
        }
        /// <summary>
        /// Add two expression values
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="index"></param>
        /// <param name="currentIndex"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        private CalcOperation<double> AddSubtractCalc(IList<OperatorEvaluator> symbols, int index, out int currentIndex, ILogger logger)
        {
            var leftSide = MultiplyDivideCalc(symbols, index, out index, logger);
            while (index < symbols.Count)
            {
                if (!(symbols[index] is OperatorService currentSymbol) || currentSymbol.OperatorType == OperatorType.Multiply || currentSymbol.OperatorType == OperatorType.Divide || currentSymbol.OperatorType == OperatorType.Mod || currentSymbol.OperatorType == OperatorType.sqrt)
                {
                    currentIndex = index;
                    return leftSide;
                }
                index += 1;
                CalcOperation<double> rightSide = MultiplyDivideCalc(symbols, index, out index, logger);

                switch (currentSymbol.OperatorType)
                {
                    case OperatorType.Add:
                        leftSide = new AddOperation(leftSide, rightSide);
                        break;
                    case OperatorType.Subtract:
                        leftSide = new SubtractOperation(leftSide, rightSide);
                        break;
                    case OperatorType.sqrt:
                        leftSide = new SqrtOperation(leftSide);
                        break;
                }
            }
            currentIndex = index;
            return leftSide;

        }
        /// <summary>
        /// multiply and divide two expression
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="index"></param>
        /// <param name="currentIndex"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        private CalcOperation<double> MultiplyDivideCalc(IList<OperatorEvaluator> symbols, int index, out int currentIndex, ILogger logger)
        {
            var leftSide = GetUnaryOperation(symbols, index, out index, logger);
            while (index < symbols.Count())
            {
                if (!(symbols[index] is OperatorService currentSymbol) || currentSymbol.OperatorType == OperatorType.Add || currentSymbol.OperatorType == OperatorType.Subtract)
                {
                    currentIndex = index;
                    return leftSide;
                }
                switch (currentSymbol.OperatorType)
                {
                    case OperatorType.sqrt:
                        leftSide = new SqrtOperation(leftSide);
                        index += 1;
                        continue;
                }
                index += 1;
                var rightSide = GetUnaryOperation(symbols, index, out index, logger);

                switch (currentSymbol.OperatorType)
                {
                    case OperatorType.Multiply:
                        leftSide = new MultiplyOperation(leftSide, rightSide);
                        break;
                    case OperatorType.Divide:
                        leftSide = new DivideOperation(leftSide, rightSide);
                        break;
                    case OperatorType.Mod:
                        leftSide = new ModOperation(leftSide, rightSide);
                        break;
                }
            }
            currentIndex = index;
            return leftSide;
        }
        /// <summary>
        /// evaluate unary operation for an operation
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="index"></param>
        /// <param name="currentIndex"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        private CalcOperation<double> GetUnaryOperation(IList<OperatorEvaluator> symbols, int index, out int currentIndex, ILogger logger)
        {
            while (index < symbols.Count)
            {
                if (symbols[index] is OperatorService currentSymbol)
                {
                    switch (currentSymbol.OperatorType)
                    {
                        case OperatorType.Add:
                            index += 1;
                            continue;
                        case OperatorType.Subtract:
                            index += 1;
                            var rightSide = GetUnaryOperation(symbols, index, out index, logger);
                            currentIndex = index;
                            return new SubstractUnaryOperation(rightSide);
                        case OperatorType.sqrt:
                            index += 1;
                            continue;
                    }

                }
                var unarySymbol = GetNumber(symbols, index, out index, logger);
                currentIndex = index;
                return unarySymbol;
            }
            logger.Error("unary operation failed");
            throw new CustomException("unary operation failed");

        }
        /// <summary>
        /// get number from expression to be evaluated
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="index"></param>
        /// <param name="currentIndex"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        private CalcOperation<double> GetNumber(IList<OperatorEvaluator> symbols, int index, out int currentIndex, ILogger logger)
        {
            if (symbols[index] is NumberService)
            {
                var currentSymbol = symbols[index] as NumberService;
                var operation = new NumberOperation(currentSymbol.Number);

                currentIndex = index + 1;
                return operation;
            }

            if (symbols[index] is FunctionService)
            {
                var currentSymbol = symbols[index] as FunctionService;
                if (currentSymbol.SpecialSymbolType == SpecialSymbolType.OpenBrackets)
                {
                    index += 1;
                    var sumWithSubtractCalc = AddSubtractCalc(symbols, index, out index, logger);
                    currentIndex = index + 1;
                    return sumWithSubtractCalc;
                }
            }
            logger.Error($"Unexpected symbol:{symbols[index]}");
            throw new CustomException($"Unexpected symbol:{symbols[index]}");
        }
    }
}
