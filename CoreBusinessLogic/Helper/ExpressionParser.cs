using CoreBusinessLogic.Interface;
using CoreBusinessLogic.Models.Enums;
using CoreBusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CoreBusinessLogic.Helper
{
    public class ExpressionParser : IParser
    {
        public IList<OperatorEvaluator> Parse(string expression) => CheckValue(expression.Replace(" ", ""));
        /// <summary>
        /// parse the expression into symbolsList
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private IList<OperatorEvaluator> CheckValue(string expression)
        {
            var listOfSymbols = new List<OperatorEvaluator>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (!char.IsDigit(expression[i]) && expression[i] != '.')
                {
                    switch (expression[i])
                    {
                        case '(':
                            listOfSymbols.Add(new FunctionService(SpecialSymbolType.OpenBrackets));
                            break;
                        case ')':
                            listOfSymbols.Add(new FunctionService(SpecialSymbolType.CloseBrackets));
                            break;
                        case '+':
                            listOfSymbols.Add(new OperatorService(OperatorType.Add));
                            break;
                        case '-':
                            listOfSymbols.Add(new OperatorService(OperatorType.Subtract));
                            break;
                        case '*':
                            listOfSymbols.Add(new OperatorService(OperatorType.Multiply));
                            break;
                        case '/':
                            listOfSymbols.Add(new OperatorService(OperatorType.Divide));
                            break;                       
                        default: throw new FormatException($"UnExpected symbol {expression[i]}");
                    }
                }
                else
                {
                    var number = ConvertToBaseNumber(expression, i, out i);
                    listOfSymbols.Add(new NumberService(number));
                    continue;
                }

            }
            return listOfSymbols;
        }
        //get number
        private double ConvertToBaseNumber(string expression, int index, out int currentIndex)
        {
            var stringNumber = new StringBuilder();
            bool isDouble = false;

            while (index < expression.Length)
            {
                if (char.IsDigit(expression[index]) || !isDouble && expression[index] == '.')
                {
                    stringNumber.Append(expression[index]);
                    isDouble = expression[index] == '.';
                    index += 1;
                    continue;
                }
                break;
            }
            currentIndex = index - 1;
            var number = double.Parse(stringNumber.ToString(), CultureInfo.InvariantCulture);
            return number;
        }
    }
}
