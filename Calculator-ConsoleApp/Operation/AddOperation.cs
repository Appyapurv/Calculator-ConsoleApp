using Calculator_ConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Operation
{
    public class AddOperation : Operation
    {
        public AddOperation(CalcOperation leftSide, CalcOperation rightSide) : base(leftSide, rightSide, (a, b) => a + b) { }

    }
}
