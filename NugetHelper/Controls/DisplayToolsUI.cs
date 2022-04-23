using NLog;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NugetHelper.Controls
{
    public static class DisplayToolsUI
    {
        /// <summary>
        /// Writes a welcome message to the console
        /// </summary>
        public static void WriteWelcome()
        {
            int filler = 5;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine($"\nWelcome to the NugetHelper\n");

            Console.WriteLine($"This helper will automate your push operations making easy to read Assembly versions of your nuget packages\n");

            Console.WriteLine("The following commands are available:\n");

            foreach (Commands item in Enum.GetValues(typeof(Commands)))
            {
                Console.WriteLine($"-{item}:\n");

                switch (item)
                {
                    case Commands.Path:
                        Console.WriteLine($"{StringTools.GenerateSpaceString(filler)}The command {item} is used to define the location of the \"Nuget.exe\" file that will allow us" +
                            "to perform the operations with your Artifact or Repository\n");
                        break;
                    case Commands.Feed:
                        Console.WriteLine($"{StringTools.GenerateSpaceString(filler)}The command {item} is used to define the address of your repository\n");
                        break;
                    case Commands.Push:
                        Console.WriteLine($"{StringTools.GenerateSpaceString(filler)}The command {item} is used to push to the selected feed\n");
                        break;
                    case Commands.Update:
                        Console.WriteLine($"{StringTools.GenerateSpaceString(filler)}The command {item} is used to update a package with the selected id, if a feed is not selected" +
                            $"it will try every nuget repository, if a feed is selected it will only try the selected feed\n");
                        break;
                    case Commands.PackageId:
                        Console.WriteLine($"{StringTools.GenerateSpaceString(filler)}The command {item} is used to define a package id used for updating purposes\n");
                        break;
                    case Commands.Exit:
                        Console.WriteLine($"{StringTools.GenerateSpaceString(filler)}The command {item} is used to close the app\n");
                        break;
                    default:
                        break;
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Writes an error message and errror number to the console in background color <see cref="ConsoleColor.Red"/>
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorText"></param>
        public static void WriteError(int errorCode, string errorText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error number {errorCode}: {errorText}");
            Console.ResetColor();
            Logger log = LogManager.GetCurrentClassLogger();
            log.Error(errorText);
        }

        /// <summary>
        /// Writes an error message to the console in background color <see cref="ConsoleColor.Red"/>
        /// </summary>
        /// <param name="errorText"></param>
        public static void WriteError(string errorText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorText);
            Console.ResetColor();
            Logger log = LogManager.GetCurrentClassLogger();
            log.Error(errorText);
        }

        /// <summary>
        /// Writes a message to the console in background color <see cref="ConsoleColor.Yellow"/>
        /// </summary>
        /// <param name="message"></param>
        public static void WriteMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Writes an asnwer to the console in background color <see cref="ConsoleColor.Blue"/>
        /// </summary>
        /// <param name="answer"></param>
        public static void WriteAnswer(string answer)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{answer}");
            Console.ResetColor();
        }

        /// <summary>
        /// Delete last line in console
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            ClearConsoleLines(1);
        }

        /// <summary>
        /// Delete a selected number of lines in console, starting from bottom to Top
        /// </summary>
        /// <param name="numberOfLines"></param>
        public static void ClearConsoleLines(int numberOfLines)
        {
            int currentLineCursor = Console.CursorTop;

            if (currentLineCursor >= numberOfLines && numberOfLines > 0)
            {
                for (int i = 1; i <= numberOfLines; i++)
                {
                    Console.SetCursorPosition(0, currentLineCursor - i);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, currentLineCursor);
                }

                return;
            }
            else if (numberOfLines == 0)
            {
                throw new ArgumentException("The number of lines to be cleared must be bigger than 0");
            }
            throw new ArgumentException("The number of lines to be cleared is bigger as the buffer");
        }

        /// <summary>
        /// Clears the number of lines in the console app and reset the cursor to top also to the
        /// selected number of lines
        /// </summary>
        /// <param name="numberOfLines"></param>
        public static void ClearAndCursorReset(int numberOfLines)
        {
            ClearConsoleLines(numberOfLines);
            Console.CursorTop -= numberOfLines;
        }

        /// <summary>
        /// Get the properties of a defined <paramref name="objectToBeSearched"/> and write the properties names and values 
        /// in the console
        /// </summary>
        /// <param name="objectToBeSearched"></param>
        public static void WritePropertiesInConsole(object objectToBeSearched)
        {
            PropertyInfo[] objectInfos = objectToBeSearched.GetType().GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo info in objectInfos)
            {
                if (!(info.PropertyType.IsGenericType))
                {
                    try
                    {
                        Console.WriteLine($"{info.Name} : {info.GetValue(objectToBeSearched)}");
                    }
                    catch (Exception Ex)
                    {
                        DisplayToolsUI.WriteError($"{ info.Name} : {Ex.Message}");
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Display the data of <paramref name="dataToBeDisplayed"/> in the console
        /// </summary>
        /// <param name="dataToBeDisplayed"></param>
        public static void WriteListInConsole(List<string> dataToBeDisplayed)
        {
            foreach (string data in dataToBeDisplayed)
            {
                WriteAnswer(data);
            }
        }
    }
}
