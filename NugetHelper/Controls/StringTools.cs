using System;

namespace NugetHelper.Controls
{
    public static class StringTools
    {
        /// <summary>
        /// Generates an space string
        /// </summary>
        /// <param name="length"></param>
        /// <returns>
        /// A concatenated space <see cref="string"/> with a <paramref name="length"/>
        /// </returns>
        public static string GenerateSpaceString(int length)
        {
            return GenerateCharString(' ', length);
        }

        /// <summary>
        /// Generates a <see cref="char"/> <see cref="string"/>
        /// </summary>
        /// <param name="character"></param>
        /// <param name="length"></param>
        /// <returns>
        /// A concatenated <paramref name="character"/> <see cref="string"/> with a defined 
        /// <paramref name="length"/>
        /// </returns>
        public static string GenerateCharString(this char character, int length)
        {
            if (length > 0)
            {
                string output = string.Empty;

                for (int i = 0; i < length; i++)
                {
                    string space = character.ToString();

                    output += string.Concat(space);
                }

                return output;
            }

            throw new ArgumentOutOfRangeException("The length must be greater than 0");
        }
    }
}
