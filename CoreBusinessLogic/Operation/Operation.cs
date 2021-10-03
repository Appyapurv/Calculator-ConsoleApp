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
        private readonly Func<double, double> _operation;

        protected Operation(CalcOperation<double> leftSide, CalcOperation<double> rightSide, Func<double, double, double> operatorFunction)
        {
            _leftSide = leftSide;
            _rightSide = rightSide;
            _operatorFunction = operatorFunction;
        }

        protected Operation(CalcOperation<double> leftSide, Func<double, double> @operation)
        {
            _leftSide = leftSide;
            _operation = operation;
        }

        /// <summary>
        /// calculate override method which will calculate the leftside and rightside values
        /// </summary>
        /// <returns></returns>
        public override double Calculate()
        {

            if (_rightSide?.Calculate() == null)
            {
                return _operation(_leftSide.Calculate());
            }
            return _operatorFunction(_leftSide.Calculate(), _rightSide.Calculate());
        }

    }
}
