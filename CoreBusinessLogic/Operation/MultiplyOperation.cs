using CoreBusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Operation
{
    public class MultiplyOperation : Operation
    {
        /// <summary>
        /// Multiply operation of two number
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        public MultiplyOperation(CalcOperation<double> leftSide, CalcOperation<double> rightSide) : base(leftSide, rightSide, (a, b) => a * b) { }
    }
}
