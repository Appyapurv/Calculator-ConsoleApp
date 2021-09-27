using Calculator_ConsoleApp.Builders;
using Calculator_ConsoleApp.Extension;
using Calculator_ConsoleApp.Utilities;
using CoreBusinessLogic.Helper;
using CoreBusinessLogic.Interface;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using static Calculator_ConsoleApp.Calculator;

namespace Calculator_ConsoleApp
{
    class Program
    {
        //Main function
        internal static void Main(string[] args)
        {
            var solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var logger = ExtensionsMethods.LoggerSetup(solutionPath);

            var service = new ServiceCollection()
             .AddScoped<IParser, ExpressionParser>()
             .AddScoped<IOperationBuilder, OperationBuilder>()
             .BuildServiceProvider();

            var parser = service.GetService<IParser>();
            var builder = service.GetService<IOperationBuilder>();

            Run(parser, builder, logger);

        }
        /// <summary>
        /// Run method for user input  
        /// </summary>
        /// <param name="logger"></param>
        public static void Run(IParser parser, IOperationBuilder builder, ILogger logger)
        {
            Console.WriteLine("------------Calculator Console Application------------");
            logger.Information("------------Calculator Application started ------------");
            while (true)
            {
                var calculator = new Calculator(parser, builder);
                Console.WriteLine("Enter any value to calculate:");
                var expression = Console.ReadLine();
                logger.Information($"Value Entered to calculate: {expression}");
                switch (expression)
                {
                    case "exit":
                    case "quit":
                        return;

                    default:
                        try
                        {
                            InputValidator.Validate(expression, logger);
                            var result = calculator.Calculate(expression, logger);
                            Console.WriteLine($"{expression} = {result}");
                            continue;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                            logger.Error($" FormatException : {ex.Message}");
                            continue;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            logger.Error($"Exception : {ex.Message}");
                            continue;
                        }
                }
            }
        }
    }
}
