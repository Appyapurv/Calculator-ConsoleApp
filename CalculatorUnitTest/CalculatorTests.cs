using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using static Calculator_ConsoleApp.Calculator;
using Serilog;
using Calculator_ConsoleApp.Utilities;
using Calculator_ConsoleApp;
using CoreBusinessLogic.Interface;
using CoreBusinessLogic.Helper;
using Calculator_ConsoleApp.Builders;

namespace CalculatorUnitTest
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        private Mock<ILogger> _logger;
        private readonly IParser _parser;
        private readonly IOperationBuilder _builder;

        /// <summary>
        /// Initializes a new instance of Calculator class.
        /// </summary>
        /// <param name="logger">The logger.</param>        
        public CalculatorTests()
        {
            _parser = new ExpressionParser();
            _builder = new OperationBuilder();
            _calculator = new Calculator(_parser, _builder);
            _logger = new Mock<ILogger>();
        }
        /// <summary>
        /// Tests to calculate the add operator result should succeeded .
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Add_Operator_ResultShouldsucceeded()
        {
            var exp = "30+40";

            var result = _calculator.Calculate(exp, _logger.Object);
            Assert.True(result.Equals(70));
        }
        /// <summary>
        /// Tests to calculate Subtract operator result should succeeded.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Subtract_Operator_ResultShoudBesucceeded()
        {
            var expression = "19-10";

            var result = _calculator.Calculate(expression, _logger.Object);

            Assert.True(result.Equals(9));
        }
        /// <summary>
        /// Tests to calculate multiply operator result should succeeded.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Multiply_Operator_ResultShoudBesucceeded()
        {
            var expression = "10 * 10";


            var result = _calculator.Calculate(expression, _logger.Object);

            Assert.True(result.Equals(100));
        }
        /// <summary>
        /// Tests to calculate divide operator result should succeeded.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Divide_Operator_ResultShoudBesucceeded()
        {
            var expression = "63 / 2";

            var result = _calculator.Calculate(expression, _logger.Object);
            Assert.True(result.Equals(31.5));
        }
        /// <summary>
        /// Tests to calculate add operator with opeator name result should succeeded.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Add_Operator_WithOperatorName_ResultShouldsucceeded()
        {
            var exp = "30 plus 40";

            var result = _calculator.Calculate(exp, _logger.Object);
            Assert.True(result.Equals(70));
        }
        /// <summary>
        /// Tests to calculate subtract operator with opeator name result should succeeded.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Subtract_Operator_WithOperatorName_ResultShoudBesucceeded()
        {
            var expression = "19 minus 10";

            var result = _calculator.Calculate(expression, _logger.Object);

            Assert.True(result.Equals(9));
        }
        /// <summary>
        /// Tests to calculate Multiply operator with opeator name result should succeeded.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Multiply_Operator_WithOperatorName_ResultShoudBesucceeded()
        {
            var expression = "10 into 10";


            var result = _calculator.Calculate(expression, _logger.Object);

            Assert.True(result.Equals(100));
        }
        /// <summary>
        /// Tests to calculate Divide operator with opeator name result should succeeded.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Divide_Operator_WithOperatorName_ResultShoudBesucceeded()
        {
            var expression = "63 divide 2";
            // Act
            var result = _calculator.Calculate(expression, _logger.Object);
            //Assert
            Assert.True(result.Equals(31.5));
        }
        /// <summary>
        /// Tests to calculate Divide operator with opeator name result should succeeded.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_complicated_Expression_ResultShoudBesucceeded()
        {
            var expression = "((2 into 4) minus 2)";
            // Act
            var result = _calculator.Calculate(expression, _logger.Object);
            //Assert
            Assert.True(result.Equals(6));
        }
        /// <summary>
        /// Tests to calculate invalid expression result should fail.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_Invalid_Expression_ResultShoudBeFailed()
        {
            var expression = "(";
            Assert.Throws<FormatException>(() => InputValidator.Validate(expression, _logger.Object));
        }
        /// <summary>
        /// Tests to check invalid brackets in expression failed.
        /// </summary>
        /// <returns></returns>  
        [Fact]
        public void Calculator_UsingStringValidatorWithWrongParentheses_ShouldThrowFormatException()
        {
            var expression = "9 - 9 * (415 - 2) + (32 / 2 +";
            // Assert
            Assert.Throws<FormatException>(() => InputValidator.Validate(expression, _logger.Object));
        }
        [Fact]
        public void Calculator_UsingStringValidatorWithWrongParentheses_WithOperatorName_ShouldThrowFormatException()
        {
            var expression = "9 minus 9 into (41 subtract 2) add (32 divide 2 sum";
            // Assert
            Assert.Throws<FormatException>(() => InputValidator.Validate(expression, _logger.Object));
        }
    }
}
