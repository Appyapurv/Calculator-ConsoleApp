using Calculator_ConsoleApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Interface
{
    public abstract class OperatorEvaluator
    {
        public abstract ExpressionType Type { get; }
    }
}
