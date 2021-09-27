using CoreBusinessLogic.Interface;
using CoreBusinessLogic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Services
{
    public class FunctionService : OperatorEvaluator
    {
        public override ExpressionType Type => ExpressionType.Parentheses;

        public SpecialSymbolType SpecialSymbolType { get; }
        public FunctionService(SpecialSymbolType specialSymbolType)
        {
            SpecialSymbolType = specialSymbolType;
        }

    }
}
