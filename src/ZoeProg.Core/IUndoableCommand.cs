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
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IUndoableCommand"/>.
    /// </summary>
    public interface IUndoableCommand
    {
        /// <summary>
        /// The ExecuteAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task ExecuteAsync();

        /// <summary>
        /// The UnExecuteAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task UnExecuteAsync();
    }
}