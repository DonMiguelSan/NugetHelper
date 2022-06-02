using NugetHelper.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetHelper.BussinessLogic
{
    public class Bootstrapper
    {
        public void Start(string[] args)
        {
            if (args.Length > 0)
            {
                var commandsDictionary = args.GetCommands();

                if (commandsDictionary.IsNugetPathAvailable())
                {

                }
                else
                {
                    throw new ArgumentNullException("The path to the \"Nuget.exe\" was not provided");
                }
            }
            else
            {
                DisplayToolsUI.WriteWelcome();
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
