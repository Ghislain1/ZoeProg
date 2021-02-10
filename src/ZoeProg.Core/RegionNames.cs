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

namespace ZoeProg.Core
{
    using System;

    /// <summary>
    /// Defines the <see cref="RegionNames"/>.
    /// </summary>
    public static class RegionNames
    {
        /// <summary>
        /// Defines the HamburgerMenuItemCollectionRegion.
        /// </summary>
        public static string HamburgerMenuItemCollectionRegion = "HamburgerMenuItemCollectionRegion";

        /// <summary>
        /// Defines the HamburgerMenuRegion.
        /// </summary>
        [Obsolete("use HamburgerMenuItemCollectionRegion instead, @GHislsin why?")]
        public static string HamburgerMenuRegion = "HamburgerMenuRegion";

        /// <summary>
        /// Defines the ListLeftRegion.
        /// </summary>
        public static string ListLeftRegion = "ListLeftRegion";

        /// <summary>
        /// Defines the LoggerRegion.
        /// </summary>
        public static string LoggerRegion = "LoggerRegion";

        /// <summary>
        /// Defines the MainRegion.
        /// </summary>
        public static string MainRegion = "MainRegion";

        /// <summary>
        /// Defines the TabRegion.
        /// </summary>
        public static string TabRegion = "TabRegion";
    }
}