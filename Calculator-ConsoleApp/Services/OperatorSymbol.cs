using Calculator_ConsoleApp.Interface;
using Calculator_ConsoleApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Services
{
    public class OperatorSymbol : OperatorEvaluator
    {
        public override ExpressionType Type => ExpressionType.Operator;

        public OperatorType OperatorType { get; }

        public OperatorSymbol(OperatorType operatorType)
        {
            OperatorType = operatorType;
        }
    }
}
