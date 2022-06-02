using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


// TODO: Refactor class and break it into different classes 
namespace NugetHelper.Controls
{
    public static class UserInteractionsUI
    {
        /// <summary>
        /// Shows the user an indication 
        /// </summary>
        /// <param name="message"></param>
        /// <returns>
        /// The <see cref="ConsoleKeyInfo"/> of the pressed key by the user
        /// </returns>
        public static ConsoleKeyInfo GetKeyInfoFromConsole(string message)
        {
            DisplayToolsUI.WriteMessage(message);

            return Console.ReadKey();
        }

        /// <summary>
        /// Generates available options and tasks that are available in the software
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the command is valid
        /// </returns>
        public static bool ExecuteCommand(out Commands optionToBeExecuted)
        {
            optionToBeExecuted = GetSelectionFromEnum<Commands>(SplitOptions.ByUpperCase);
            return optionToBeExecuted != Commands.Exit;
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
                    GetSelectedObject(collection);
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
