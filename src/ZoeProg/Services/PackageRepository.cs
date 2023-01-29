// <copyright file="PackageRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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

namespace ZoeProg.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Ghis.PowershellLib;
    using ZoeProg.Core;
    using ZoeProg.Core.Data;

    /// <summary>
    /// Defines the <see cref="PackageRepository"/>.
    /// </summary>
    public class PackageRepository : IPackageRepository
    {
        /// <summary>
        /// Defines the powerShellService.
        /// </summary>
        private readonly IPowershellService powerShellService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageRepository"/> class.
        /// </summary>
        /// <param name="powerShellService">The powerShellService <see cref="IPowershellService"/>.</param>
        public PackageRepository(IPowershellService powerShellService)
        {
            this.powerShellService = powerShellService;
        }

        /// <summary>
        /// The GetListAvailabePackages.
        /// </summary>
        /// <param name="folderName">The folderName <see cref="string"/>.</param>
        /// <param name="token">The token <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{List{Package}}"/>.</returns>
        public Task<List<Package>> GetListAvailabePackages(string folderName, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetListInstalledPackages.
        /// </summary>
        /// <param name="token">The token <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{List{InstalledPackage}}"/>.</returns>
        public async Task<List<InstalledPackage>> GetListInstalledPackages(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            string pattern = @"Name=""(?<name>.+)"",Version=""(?<version>\d.+)""";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            IEnumerable<object> psOutput = null;
            string cmd = Cmds.ListInstalledPackCmd;
            var result = new List<InstalledPackage>();
            try
            {
                psOutput = await this.powerShellService.RunCommand(token, cmd);
            }
            catch (Exception)
            {
                throw;
            }

            foreach (var item in psOutput)
            {
                token.ThrowIfCancellationRequested();

                if (!string.IsNullOrEmpty(item.ToString()))
                {
                    var package = this.CreateInstalledPackage(item.ToString(), regex);
                    result.Add(package);
                }
            }

            return result;
        }

        /// <summary>
        /// The GetListInstalledPackages.
        /// </summary>
        /// <param name="cancellationTokenSource">The cancellationTokenSource <see cref="CancellationTokenSource"/>.</param>
        /// <returns>The <see cref="Task{List{InstalledPackage}}"/>.</returns>
        public Task<List<InstalledPackage>> GetListInstalledPackages(CancellationTokenSource cancellationTokenSource)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The CreateInstalledPackage.
        /// </summary>
        /// <param name="input">The input <see cref="string"/>.</param>
        /// <param name="regex">The regex <see cref="Regex"/>.</param>
        /// <returns>The <see cref="Package"/>.</returns>
        private Package CreateInstalledPackage(string input, Regex regex)
        {
            Package installedPackage = new Package();

            var match = regex.Match(input);

            if (match.Success)
            {
                installedPackage.Title = match.Groups["name"].Value;
                installedPackage.Version = match.Groups["version"].Value;
            }
            else
            {
                throw new Exception("Impossibe");
            }

            return installedPackage;
        }

        /// <summary>
        /// Defines the <see cref="PackageService"/>.
        /// </summary>
        public class PackageService : IPackageService
        {
            /// <summary>
            /// The Install.
            /// </summary>
            /// <param name="package">The package <see cref="PackageVersion"/>.</param>
            /// <returns>The <see cref="Task"/>.</returns>
            public Task Install(PackageVersion package)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// The Install.
            /// </summary>
            /// <param name="package">The package <see cref="Package"/>.</param>
            /// <param name="onDataReceived">The onDataReceived <see cref="Action{string}"/>.</param>
            /// <param name="cancelToken">The cancelToken <see cref="CancellationToken"/>.</param>
            /// <returns>The <see cref="Task"/>.</returns>
            public Task Install(Package package, Action<string> onDataReceived, CancellationToken cancelToken)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// The Uninstall.
            /// </summary>
            /// <param name="package">The package <see cref="PackageVersion"/>.</param>
            /// <returns>The <see cref="Task"/>.</returns>
            public Task Uninstall(PackageVersion package)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// The UnInstall.
            /// </summary>
            /// <param name="package">The package <see cref="Package"/>.</param>
            /// <param name="onDataReceived">The onDataReceived <see cref="Action{string}"/>.</param>
            /// <param name="cancelToken">The cancelToken <see cref="CancellationToken"/>.</param>
            /// <returns>The <see cref="Task"/>.</returns>
            public Task UnInstall(Package package, Action<string> onDataReceived, CancellationToken cancelToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}