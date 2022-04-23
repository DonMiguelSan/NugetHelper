using System;
using System.Text.RegularExpressions;

namespace NugetHelper.Controls
{
    /// <summary>
    /// String Extension Methods
    /// </summary>
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Splits the given strings by Upper Case from A-Z and generate a new sentence with 
        /// the splitted data
        /// </summary>
        /// <param name="text"></param>
        /// <returns>
        /// A <see cref="string"/> containing a sentence formed with the splitted data from <paramref name="text"/>
        /// incluiding spaces in between
        /// </returns>
        public static string SplitByUpperCase(this string text)
        {
            string[] split = Regex.Split(text, @"(?<!^)(?=[A-Z])");

            return CreateSpacedString(split);
        }

        /// <summary>
        /// Splits the given strings by lower case from a-z and generate a new sentence with 
        /// the splitted data
        /// </summary>
        /// <param name="text"></param>
        /// <returns>
        /// A <see cref="string"/> containing a sentence formed with the splitted data from <paramref name="text"/>
        /// incluiding spaces in between
        /// </returns>
        public static string SplitByLowerCase(this string text)
        {
            string[] split = Regex.Split(text, @"(?<!^)(?=[a-z])");

            return CreateSpacedString(split);
        }

        /// <summary>
        /// Creates a string with the splitted data and adds a space in between the given data
        /// in <paramref name="data"/>
        /// </summary>
        /// <param name="data"></param>
        /// <returns>
        /// A <see cref="string"/> containing the info with separated blank spaces
        /// </returns>
        private static string CreateSpacedString(string[] data)
        {
            string output = string.Empty;

            for (int i = 0; i < data.Length; i++)
            {
                if (data.Length - i != 1)
                {
                    output += data[i] + " ";
                }
                else
                {
                    output += data[i];
                }
            }

            return output;
        }

        /// <summary>
        /// Extract the information of a string between the first brackets
        /// </summary>
        /// <param name="textWithParentesis"></param>
        /// <returns>
        /// A string containing the information between the first brackets
        /// </returns>
        public static string ExtractDataInBrackets(this string textWithParentesis)
        {
            int indexOfStartBracket = textWithParentesis.IndexOf("[");

            int indexOfEndBracket = textWithParentesis.IndexOf("]");

            if (textWithParentesis.Contains("[") && textWithParentesis.Contains("]")
                && indexOfStartBracket < indexOfEndBracket)
            {
                return textWithParentesis.Substring(indexOfStartBracket + 1, indexOfEndBracket - indexOfStartBracket - 1);
            }

            throw new ArgumentException($"The {textWithParentesis} does not contain or brackets are in wrong " +
                $"position");
        }


    }
}
