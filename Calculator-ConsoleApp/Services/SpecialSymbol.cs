using Calculator_ConsoleApp.Interface;
using Calculator_ConsoleApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Services
{
    public class SpecialSymbol : OperatorEvaluator
    {
        public override ExpressionType Type => ExpressionType.Parentheses;

        public SpecialSymbolType SpecialSymbolType { get; }
        public SpecialSymbol(SpecialSymbolType specialSymbolType)
        {
            SpecialSymbolType = specialSymbolType;
        }

    }
}
