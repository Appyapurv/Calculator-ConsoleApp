using Calculator_ConsoleApp.Interface;
using Calculator_ConsoleApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Calculator_ConsoleApp.Services
{
    public class StringParser : IParser
    {
        public IList<OperatorEvaluator> Parse(string expression) => CheckValue(expression.Replace(" ", ""));

        private IList<OperatorEvaluator> CheckValue(string expression)
        {
            var symbols = new List<OperatorEvaluator>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (!char.IsDigit(expression[i]) && expression[i] != '.')
                {
                    switch (expression[i])
                    {
                        case '+':
                            symbols.Add(new OperatorSymbol(OperatorType.Add));
                            break;
                        case '-':
                            symbols.Add(new OperatorSymbol(OperatorType.Subtract));
                            break;
                        case '*':
                            symbols.Add(new OperatorSymbol(OperatorType.Multiply));
                            break;
                        case '/':
                            symbols.Add(new OperatorSymbol(OperatorType.Divide));
                            break;
                        case '(':
                            symbols.Add(new SpecialSymbol(SpecialSymbolType.OpenBrackets));
                            break;
                        case ')':
                            symbols.Add(new SpecialSymbol(SpecialSymbolType.CloseBrackets));
                            break;
                        default: throw new FormatException($"UnExpected symbol {expression[i]}");
                    }
                }
                else
                {
                    var number = GetNumber(expression, i, out i);
                    symbols.Add(new NumberSymbol(number));
                    continue;
                }

            }
            return symbols;
        }

        private double GetNumber(string expression, int index, out int currentIndex)
        {
            var StringNumber = new StringBuilder();
            bool isDouble = false;

            while (index < expression.Length)
            {
                if (char.IsDigit(expression[index]) || !isDouble && expression[index] == '.')
                {
                    StringNumber.Append(expression[index]);
                    isDouble = expression[index] == '.';
                    index += 1;
                    continue;
                }
                break;
            }
            currentIndex = index - 1;
            var number = double.Parse(StringNumber.ToString(), CultureInfo.InvariantCulture);
            return number;
        }
    }
}
