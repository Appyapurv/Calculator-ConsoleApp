using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator_ConsoleApp.Utilities
{
    public class InputValidator
    {
        /// <summary>
        /// expression validator method
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="logger"></param>
        public static Tuple<bool, string> Validate(string expression, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                logger.Error("Expression is Empty");
                return new Tuple<bool, string>(false, "Expression is Empty");
                //throw new FormatException("Expression is Empty");

            }

            var openBracketCount = expression.Count(c => c == '(');
            var closeBracketCount = expression.Count(c => c == ')');

            if (openBracketCount != closeBracketCount)
            {
                logger.Error("Wrong no of parenthesis");
                return new Tuple<bool, string>(false, "Wrong no of parenthesis");
                //throw new FormatException("Wrong no of parenthesis");
            }

            var orderOfBracket = expression.Where(c => c == '(' || c == ')').Aggregate("", (current, next) => current + next);

            while (orderOfBracket.Contains("(" + ")"))
                orderOfBracket = orderOfBracket.Replace("(" + ")", "");

            if (!string.IsNullOrEmpty(orderOfBracket))
            {
                logger.Error("Wrong order of bracket in the expression");
                return new Tuple<bool, string>(false, "Wrong order of bracket in the expression");
                //throw new FormatException("Wrong order of bracket in the expression");
            }
            return new Tuple<bool, string>(true, "Success");
        }
    }
}
