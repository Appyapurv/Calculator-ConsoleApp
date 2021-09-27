using CoreBusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Operation
{
    public abstract class Operation : CalcOperation<double>
    {
        private readonly CalcOperation<double> _leftSide;
        private readonly CalcOperation<double> _rightSide;
        private readonly Func<double, double, double> _operatorFunction;

        protected Operation(CalcOperation<double> leftSide, CalcOperation<double> rightSide, Func<double, double, double> operatorFunction)
        {
            _leftSide = leftSide;
            _rightSide = rightSide;
            _operatorFunction = operatorFunction;
        }
        /// <summary>
        /// calculate override method which will calculate the leftside and rightside values
        /// </summary>
        /// <returns></returns>
        public override double Calculate() => _operatorFunction(_leftSide.Calculate(), _rightSide.Calculate());
    }
}
