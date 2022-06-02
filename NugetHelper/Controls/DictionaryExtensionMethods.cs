using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NugetHelper.Controls
{
    public static class DictionaryExtensionMethods
    {
        // TODO: Migrate to a tools library to have it available as an extension method
        /// <summary>
        /// Get the <see cref="KeyValuePair{TKey, TValue}"/> from <paramref name="dictionary"/> stored with
        /// <paramref name="key"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns>
        /// A <see cref="KeyValuePair{TKey, TValue}"/> containing the realted pair from <paramref name="dictionary"/>
        /// </returns>
        public static KeyValuePair<T, U> GetValuePair<T, U>(this Dictionary<T, U> dictionary, T key)
	    {
            if (dictionary.ContainsKey(key))
            {
                KeyValuePair<T, U> output =
                   new KeyValuePair<T, U>(key, dictionary[key]);

                return output; 
            }

            throw new ArgumentNullException($"The key: {key} does not exist in dictionary: {dictionary}");
        }
    }
}
