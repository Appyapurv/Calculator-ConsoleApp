using CoreBusinessLogic.Interface;
using CoreBusinessLogic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Services
{
    public class OperatorService : OperatorEvaluator
    {
        public override ExpressionType Type => ExpressionType.Operator;

        public OperatorType OperatorType { get; }

        public OperatorService(OperatorType operatorType)
        {
            OperatorType = operatorType;
        }
    }
}
