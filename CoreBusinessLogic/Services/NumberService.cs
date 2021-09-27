using CoreBusinessLogic.Interface;
using CoreBusinessLogic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Services
{
    public class NumberService : OperatorEvaluator
    {
        public double Number { get; }
        public override ExpressionType Type => ExpressionType.Number;

        public NumberService(double number)
        {
            Number = number;
        }
    }
}
