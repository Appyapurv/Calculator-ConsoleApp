using Calculator_ConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Operation
{
    public class SubstractUnaryOperation : UnaryOperation
    {
        public SubstractUnaryOperation(CalcOperation rightSide) : base(rightSide, (a) => -a) { }

    }
}
