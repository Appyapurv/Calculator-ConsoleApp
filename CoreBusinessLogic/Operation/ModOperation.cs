using CoreBusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Operation
{
    public class ModOperation : Operation
    {
        public ModOperation(CalcOperation<double> leftSide, CalcOperation<double> rightSide) : base(leftSide, rightSide, (a, b) => a % b) { }
    }
}
