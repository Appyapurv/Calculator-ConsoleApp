using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Interface
{
    public abstract class UnaryOperation : CalcOperation
    {
        private readonly CalcOperation _rightSide;
        private readonly Func<double, double> _operator;

        public UnaryOperation(CalcOperation rightSide, Func<double, double> @operator)
        {
            _rightSide = rightSide;
            _operator = @operator;
        }
        public override double Calculate() => _operator(_rightSide.Calculate());
    }
}
