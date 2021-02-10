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
    /// <summary>
    /// How to find WMI information with PowerShell.
    /// </summary>
    public class Cmds
    {
        /// <summary>
        /// Defines the InstalledPackCmd.
        /// </summary>
        public static string InstalledPackCmd = @"Get-ItemProperty HKLM:\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\*";

        /// <summary>
        /// Defines the ListInstalledPackCmd.
        /// </summary>
        public static string ListInstalledPackCmd = "Get-WmiObject -Class Win32_Product";
    }
}