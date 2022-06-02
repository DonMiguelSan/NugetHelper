using NugetHelper.BussinessLogic;
using Xunit;

namespace NugetHelper.Tests
{
    public class BootstrapperTests
    {
        [Theory(Skip = "Start Method is in development, a testable version is not realeased")]
        [InlineData(new object[] { new string[] { "", "" } })]
        [InlineData(new object[] { new string[] { "C:\\nuget.exe ", "StartNuget" } })]
        private void StartTest(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            var exception = Record.Exception(() =>

                    bootstrapper.Start(args)
            );

            Assert.Null(exception);
        }
    }
}
