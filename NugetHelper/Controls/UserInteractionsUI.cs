using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NugetHelper.Controls
{
    public static class UserInteractionsUI
    {

        public static ConsoleKeyInfo GetKeyInfoFromConsole(string message)
        {
            DisplayToolsUI.WriteMessage(message);

            return Console.ReadKey();
        }

        /// <summary>
        /// Generates available options and tasks that are available in the software
        /// </summary>
        /// <returns>
        /// True if program must continue running
        /// </returns>
        public static bool GetTaskToBeRun(out OptionsToRun optionToBeExecuted)
        {
            optionToBeExecuted = GetSelectionFromEnum<OptionsToRun>(SplitOptions.ByUpperCase);
            return optionToBeExecuted != OptionsToRun.CloseNugetHelper;
        }

        public static T GetSelectionFromEnum<T>(SplitOptions splitOption = SplitOptions.None) where T : Enum
        {

            DisplayToolsUI.WriteMessage("\nFollowing operations are available:\n");

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                switch (splitOption)
                {
                    case SplitOptions.ByUpperCase:
                        DisplayToolsUI.WriteMessage($"{(short)item}: {item.ToString().SplitByUpperCase()}");
                        break;
                    case SplitOptions.ByLowerCase:
                        DisplayToolsUI.WriteMessage($"{(short)item}: {item.ToString().SplitByLowerCase()}");
                        break;
                    case SplitOptions.None:
                        DisplayToolsUI.WriteMessage($"{(short)item}: {item}");
                        break;
                }

            }

            T output = default;

            if (short.TryParse(Console.ReadLine(), out short selectedOption))
            {
                DisplayToolsUI.ClearCurrentConsoleLine();
                output = (T)Enum.ToObject(typeof(T), selectedOption);
                switch (splitOption)
                {
                    case SplitOptions.ByUpperCase:
                        DisplayToolsUI.WriteMessage($"Opiton {selectedOption} is selected: {output.ToString().SplitByUpperCase()}");
                        break;
                    case SplitOptions.ByLowerCase:
                        DisplayToolsUI.WriteMessage($"Opiton {selectedOption} is selected: {output.ToString().SplitByLowerCase()}");
                        break;
                    case SplitOptions.None:
                        DisplayToolsUI.WriteMessage($"Opiton {selectedOption} is selected: {output}");
                        break;
                }
            }
            else
            {
                GetSelectionFromEnum<T>();
            }
            return output;
        }

        /// <summary>
        /// Select an object according to user interacion returning a object type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns>
        /// An object <typeparamref name="T"/> according to selection through the GUI
        /// </returns>
        public static T GetSelectedObject<T>(List<T> collection, string customMessage = "", string propertyToBeShowed = "Name")
        {
            if (collection.Count > 1)
            {
                customMessage = string.IsNullOrEmpty(customMessage) ? "Select an option from the following list" : customMessage;

                DisplayToolsUI.WriteMessage(customMessage);

                int optionIndex = 0;

                foreach (T member in collection)
                {
                    PropertyInfo property = member.GetType().GetProperty(propertyToBeShowed);

                    if (property is null)
                    {
                        DisplayToolsUI.WriteMessage($"{optionIndex}: {member}");
                    }
                    else
                    {
                        DisplayToolsUI.WriteMessage($"{optionIndex}: {property.GetValue(member)}");
                    }
                    optionIndex++;
                }
                if (!(short.TryParse(Console.ReadLine(), out short selectedIndex) && selectedIndex >= 0
                   && selectedIndex <= collection.Count - 1))
                {
                    DisplayToolsUI.ClearCurrentConsoleLine();
                    DisplayToolsUI.WriteError("The selected option is not valid");
                    GetSelectedObject<T>(collection);
                }

                DisplayToolsUI.ClearCurrentConsoleLine();

                return collection[selectedIndex];
            }
            else
            {
                return collection.First();
            }
        }


    }
}
