using NugetHelper.BussinessLogic;
using System;

namespace NugetHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bootstrapper bootstrapper = new Bootstrapper();

                bootstrapper.Start(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}:{ex.StackTrace}");
                throw new Exception("Exception", ex);
            }
        }

    }
}
