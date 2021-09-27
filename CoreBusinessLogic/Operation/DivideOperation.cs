using CoreBusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Operation
{
    public class DivideOperation : Operation
    {
        /// <summary>
        /// Divide operation of two number
        /// </summary>
        /// <param name="leftSide"></param>
        /// <param name="rightSide"></param>
        public DivideOperation(CalcOperation<double> leftSide, CalcOperation<double> rightSide) : base(leftSide, rightSide, (a, b) => a / b) { }
    }
}
