using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ConsoleApp.Extension
{
    public class CustomException : Exception
    {
        public CustomException(string exception) : base(String.Format("CustomException: {0}", exception)) { }
    }
}
