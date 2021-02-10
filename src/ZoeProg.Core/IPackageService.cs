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
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Core.Data;

    /// <summary>
    /// Defines the <see cref="IPackageService"/>.
    /// </summary>
    public interface IPackageService
    {
        /// <summary>
        /// The Install.
        /// </summary>
        /// <param name="package">The package <see cref="PackageVersion"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Install(PackageVersion package);

        /// <summary>
        /// The Install.
        /// </summary>
        /// <param name="package">The package <see cref="Package"/>.</param>
        /// <param name="onDataReceived">The onDataReceived <see cref="Action{string}"/>.</param>
        /// <param name="cancelToken">The cancelToken <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Install(Package package, Action<string> onDataReceived, CancellationToken cancelToken);

        /// <summary>
        /// The Uninstall.
        /// </summary>
        /// <param name="package">The package <see cref="PackageVersion"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Uninstall(PackageVersion package);

        /// <summary>
        /// The UnInstall.
        /// </summary>
        /// <param name="package">The package <see cref="Package"/>.</param>
        /// <param name="onDataReceived">The onDataReceived <see cref="Action{string}"/>.</param>
        /// <param name="cancelToken">The cancelToken <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task UnInstall(Package package, Action<string> onDataReceived, CancellationToken cancelToken);
    }
}