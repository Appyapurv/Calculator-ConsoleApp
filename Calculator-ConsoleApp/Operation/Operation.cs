using Calculator_ConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Operation
{
    public abstract class Operation : CalcOperation
    {
        private readonly CalcOperation _leftSide;
        private readonly CalcOperation _rightSide;
        private readonly Func<double, double, double> _operator;

        public Operation(CalcOperation leftSide, CalcOperation rightSide, Func<double, double, double> @operator)
        {
            _leftSide = leftSide;
            _rightSide = rightSide;
            _operator = @operator;
        }

        public override double Calculate() => _operator(_leftSide.Calculate(), _rightSide.Calculate());
    }
}
