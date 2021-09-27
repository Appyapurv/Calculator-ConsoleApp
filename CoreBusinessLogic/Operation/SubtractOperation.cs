using CoreBusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Operation
{
    public class SubtractOperation : Operation
    {
        /// <summary>
        /// subtract operation for two number
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        public SubtractOperation(CalcOperation<double> leftSide, CalcOperation<double> rightSide) : base(leftSide, rightSide, (a, b) => a - b) { }
    }
}
