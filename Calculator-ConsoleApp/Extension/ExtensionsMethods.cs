using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator_ConsoleApp.Extension
{
    public static class ExtensionsMethods
    {
        /// <summary>
        /// logger Setup method
        /// </summary>
        /// <param name="path"></param>
        /// <returns>logger instance</returns>
        public static ILogger LoggerSetup(this string path)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(Path.Combine(path, "logs\\logfile.txt"))
            .CreateLogger();
            return logger;
        }
        /// <summary>
        /// convert into operation
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="logger"></param>
        /// <returns>string of opeation</returns>
        public static string ConvertIntoOperation(this string expression, ILogger logger)
        {
            var stringBuilder = new StringBuilder();
            var splitList = expression.ToLower().Split();
            var dictionary = new Dictionary<string, char>();
            dictionary.Add("plus", '+');
            dictionary.Add("add", '+');
            dictionary.Add("sum", '+');
            dictionary.Add("minus", '-');
            dictionary.Add("subtract", '-');
            dictionary.Add("into", '*');
            dictionary.Add("multiply", '*');
            dictionary.Add("divide", '/');


            foreach (var expr in splitList)
            {
                stringBuilder = dictionary.TryGetValue(expr, out char value) ? stringBuilder.Append(value) : stringBuilder.Append(expr);
            }
            logger.Information($"ConvertedIntoOperation : {stringBuilder.ToString()}");
            return stringBuilder.ToString();
        }
    }
}
