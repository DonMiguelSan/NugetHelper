using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    if (args[0].Equals("NugetStart", StringComparison.InvariantCultureIgnoreCase))
                    {
                        StartNuget(args[1]);
                    }
                    else
                    {
                        throw new ArgumentException("No valid arguments were provided");
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"{Ex.Message}:{Ex.StackTrace}");
                
            }
        }

        static void StartNuget(string path)
        {
            Console.WriteLine("Nuget is starting");

            ProcessStartInfo startinfo = new ProcessStartInfo(path)
            {
                CreateNoWindow = false,
                UseShellExecute = false
            };

            Process p = Process.Start(startinfo);

            p.WaitForExit();           

        }

    }
}
