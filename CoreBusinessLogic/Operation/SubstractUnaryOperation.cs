using CoreBusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Operation
{
    public class SubstractUnaryOperation : UnaryOperation
    {
        /// <summary>
        /// subtract unary operation of number
        /// </summary>
        /// <param name="rightSide"></param>
        public SubstractUnaryOperation(CalcOperation<double> rightSide) : base(rightSide, (a) => -a) { }

    }
}
