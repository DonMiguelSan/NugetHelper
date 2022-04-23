using NugetHelper.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NugetHelper.Tests
{
    public class UserInteractionsUITests
    {
        [Fact]
        public void GetCommandsTest()
        {
            Dictionary<Commands, List<string>> actual = 
                UserInteractionsUI.GetCommands(GetSimulatedArgs(out int expectedNumberOfCommands));

            // Compares the number of commands Actual vs Expected
            Assert.Equal(expectedNumberOfCommands, actual.Keys.Count);
        }

        /// <summary>
        /// Generates muster data to simulate input arguments from the console
        /// </summary>
        /// <param name="numberOfCommands"></param>
        /// <returns>
        /// An <see cref="Array"/> of <see cref="string"/> containig the simulated data
        /// </returns>
        public static string[] GetSimulatedArgs(out int numberOfCommands)
        {
            List<string> arguments = new List<string>()
            {
                "-Path",
                "C:\\nuget.exe",
                "-Feed",
                "MyFeed",
                "-PackageId",
                "ServicePackage",
                "Simagician",
                "Supervisor",
                "-Exit"
            };

            numberOfCommands = arguments.Where(x=>x.StartsWith(StringConstants.commandHeaderFlag)).Count();

            string[] output = arguments.ToArray();

            return output;
        }
    }
}
