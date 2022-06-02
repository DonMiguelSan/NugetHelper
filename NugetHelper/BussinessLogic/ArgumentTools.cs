using NugetHelper.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetHelper.BussinessLogic
{
    public static class ArgumentTools
    {
        /// <summary>
        /// Filter the <paramref name="args"/> in different commands with their respective parameters
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Dictionary<Commands, List<string>> GetCommands(this string[] args)
        {
            Dictionary<Commands, List<string>> commandDictionary = new Dictionary<Commands, List<string>>();

            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].IsCommand() && Enum.TryParse(args[i].RemoveHeaderFlag(), out Commands selectedCommand))
                    {
                        if (commandDictionary.ContainsKey(selectedCommand) == false)
                        {
                            commandDictionary.Add(selectedCommand, new List<string>());
                        }
                        for (int j = i + 1; j < args.Length; j++)
                        {
                            if (args[j].IsCommand())
                            {
                                i = j - 1;
                                break;
                            }
                            commandDictionary[selectedCommand].Add(args[j]);
                        }
                    }
                }

                return commandDictionary;
            }
            throw new ArgumentException("No arguments provided");
        }

        /// <summary>
        /// Checks if in a defined <paramref name="commandsDictionary"/> the <see cref="Commands.NugetExePath" is defined/>
        /// </summary>
        /// <param name="commandsDictionary"></param>
        /// <returns>
        /// <see langword="true"/> if the <see cref="Commands.NugetExePath"/> is available and contains parameters
        /// </returns>
        public static bool IsNugetPathAvailable(this Dictionary<Commands, List<string>> commandsDictionary)
        {
            if (commandsDictionary.ContainsKey(Commands.NugetExePath))
            {
                return commandsDictionary.GetValuePair(Commands.NugetExePath).HasArgs();
            }

            return false;
        }

        /// <summary>
        /// Checks if the <paramref name="commandWithArgs"/> contains the minimum data to call the "Nuget.exe" tool
        /// </summary>
        /// <param name="commandWithArgs"></param>
        /// <returns>
        /// <see langword="true"/> if the <see cref="Commands.NugetExePath"/> contaings arguments
        /// </returns>
        public static bool HasArgs(this KeyValuePair<Commands, List<string>> commandWithArgs)
        {
            return commandWithArgs.Value.Count > 0 &&
                   string.IsNullOrEmpty(commandWithArgs.Value.FirstOrDefault()) == false;
        }

        /// <summary>
        /// Check that the arguments provided in <paramref name="commandsDictionary"/> to check if their are provided with arguments
        /// </summary>
        /// <param name="commandsDictionary"></param>
        /// <returns>
        /// <see langword="true"/> if commands are valid
        /// </returns>
        public static bool ValidateCommandArgs(this Dictionary<Commands, List<string>> commandsDictionary)
        {
            bool output = false;

            foreach (KeyValuePair<Commands, List<string>> commandWithArgs in commandsDictionary)
            {
                if ((commandWithArgs.HasArgs()
                    || commandWithArgs.Key == Commands.Exit
                    || commandWithArgs.Key == Commands.Update)
                    && commandWithArgs.Key == Commands.Push == false)
                {
                    output = true;
                }
                else if (commandWithArgs.Key == Commands.Push && commandsDictionary.TryGetValue(Commands.Feed, out var pars)
                    && pars?.Count > 0 && string.IsNullOrEmpty(pars?.FirstOrDefault()) == false) 
                {
                    output = true;
                }

                if (output)
                {
                    continue;
                }
                break;
            }

            return output;
        }
    }

   
}
