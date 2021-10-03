using CoreBusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Operation
{
    public class SqrtOperation : Operation
    {
        public SqrtOperation(CalcOperation<double> leftside) : base(leftside, (a => Math.Sqrt(a))) { }
    }
}
