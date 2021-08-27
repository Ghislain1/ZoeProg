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
    using System;
    using System.Diagnostics;
    public static class PowerShellHelper
    {
        public static void ExecuteCommand(string command, bool asAdmin = false, ProcessWindowStyle windowStyle = ProcessWindowStyle.Hidden)
        {
            var info = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -NoLogo -Command {command}",
                UseShellExecute = false,
                WindowStyle = windowStyle
            };

            if (asAdmin)
                info.Verb = "runas";

            using (var process = new Process())
            { 
                process.StartInfo = info;
                process.StartInfo.RedirectStandardOutput = true;
                
                process.Start();
                Debug.WriteLine("Output - {0}", process.StandardOutput.ReadToEnd());
                while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                // 
                Debug.WriteLine("Output - {0}", line);
            }


            process.WaitForExit();
        }
        }
    }
}
