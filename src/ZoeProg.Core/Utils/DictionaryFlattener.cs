/*-
 * ---license-start
 * Zoe-App
 * ---
 * Copyright (C) 2021 GhislainOne and all other contributors
 * ---
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ---license-end
 */

namespace ZoeProg.Core.Utils
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="DictionaryFlattener"/>.
    /// </summary>
    public static class DictionaryFlattener
    {
        /// <summary>
        /// The Flatten.
        /// </summary>
        /// <typeparam name="TCollection">.</typeparam>
        /// <param name="dictionary">The dictionary <see cref="IDictionary{string, TCollection}"/>.</param>
        /// <returns>The <see cref="ICollection{string}"/>.</returns>
        public static ICollection<string> Flatten<TCollection>(IDictionary<string, TCollection> dictionary)
        where TCollection : IEnumerable<string>
        {
            var flattenedItems = new List<string>();
            foreach (string key in dictionary.Keys)
            {
                foreach (string item in dictionary[key])
                {
                    flattenedItems.Add(key + ": " + item);
                }
            }
            return flattenedItems;
        }
    }
}