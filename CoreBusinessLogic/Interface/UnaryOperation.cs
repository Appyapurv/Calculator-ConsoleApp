using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Interface
{
    public abstract class UnaryOperation : CalcOperation<double>
    {
        private readonly CalcOperation<double> _rightSide;
        private readonly Func<double, double> _operator;


        protected UnaryOperation(CalcOperation<double> rightSide, Func<double, double> @operator)
        {
            _rightSide = rightSide;
            _operator = @operator;
        }
        public override double Calculate() => _operator(_rightSide.Calculate());
    }
}
