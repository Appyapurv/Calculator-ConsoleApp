using CoreBusinessLogic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Interface
{
    public abstract class OperatorEvaluator
    {
        public abstract ExpressionType Type { get; }
    }
}
