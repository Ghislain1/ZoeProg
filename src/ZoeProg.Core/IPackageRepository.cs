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
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Data;

    /// <summary>
    /// Defines the <see cref="IPackageRepository"/>.
    /// </summary>
    public interface IPackageRepository
    {
        /// <summary>
        /// The GetListAvailabePackages.
        /// </summary>
        /// <param name="folderName">The folderName <see cref="string"/>.</param>
        /// <param name="token">The token <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{List{Package}}"/>.</returns>
        Task<List<Package>> GetListAvailabePackages(string folderName, CancellationToken token);

        /// <summary>
        /// The GetListInstalledPackages.
        /// </summary>
        /// <param name="token">The token <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{List{InstalledPackage}}"/>.</returns>
        Task<List<InstalledPackage>> GetListInstalledPackages(CancellationToken token);

        /// <summary>
        /// The GetListInstalledPackages.
        /// </summary>
        /// <param name="cancellationTokenSource">The cancellationTokenSource <see cref="CancellationTokenSource"/>.</param>
        /// <returns>The <see cref="Task{List{InstalledPackage}}"/>.</returns>
        Task<List<InstalledPackage>> GetListInstalledPackages(CancellationTokenSource cancellationTokenSource);
    }
}