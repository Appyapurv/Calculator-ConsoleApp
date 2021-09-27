using Calculator_ConsoleApp.Interface;
using Calculator_ConsoleApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Services
{
    public class NumberSymbol : OperatorEvaluator
    {
        public double Number { get; }
        public override ExpressionType Type => ExpressionType.Number;

        public NumberSymbol(double number)
        {
            Number = number;
        }
    }
}
