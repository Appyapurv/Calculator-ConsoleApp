using CoreBusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusinessLogic.Operation
{
    public class NumberOperation : CalcOperation<double>
    {
        private readonly double _number;
        public NumberOperation(double number)
        {
            _number = number;
        }
        /// <summary>
        /// override calculate method 
        /// </summary>
        /// <returns></returns>
        public override double Calculate() => _number;
        
    }
}
