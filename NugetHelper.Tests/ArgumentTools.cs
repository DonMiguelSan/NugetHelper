using NugetHelper.BussinessLogic;
using NugetHelper.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NugetHelper.Tests
{
    public class ArgumentTools
    {
        [Fact]
        public void GetCommandsTest()
        {
            Dictionary<Commands, List<string>> actual =
                GetSimulatedArgs(out int expectedNumberOfCommands).GetCommands();

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
                "-NugetExePath",
                "C:\\nuget.exe",
                "-Feed",
                "MyFeed",
                "-PackageId",
                "ServicePackage",
                "Simagician",
                "Supervisor",
                "-Exit"
            };

            numberOfCommands = arguments.Where(x => x.StartsWith(StringConstants.commandHeaderFlag)).Count();

            string[] output = arguments.ToArray();

            return output;
        }

        [Fact]
        public void IsNugetPathAvailableTest()
        {
            var commandAvailable = GetSimulatedArgs(out _).GetCommands();
            Assert.True(commandAvailable.IsNugetPathAvailable());
        }

        [Theory]
        [InlineData(new string[] { "-NugetExePath","C:\\nuget.exe " }  , true)]
        [InlineData(new string[] { "-NugetExePath" }, false)]
        [InlineData(new string[] { "-Exit" }, true)]
        [InlineData(new string[] { "-Update" }, true)]
        [InlineData(new string[] { "-NugetExePath", "C:\\nuget.exe", "-Push", "","-Update"}, true)]
        public void CommandValidatorTest( string[] args, bool expected)
        {
            Assert.Equal(expected, args.GetCommands().ValidateCommandArgs());
        }

    }
}
