// <copyright file="TaskService.cs" company="PlaceholderCompany">
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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="TaskService"/>.
    /// </summary>
    public class TaskService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskService"/> class.
        /// </summary>
        public TaskService()
        {
        }

        /// <summary>
        /// The StartNew.
        /// </summary>
        /// <typeparam name="TResult">.</typeparam>
        /// <param name="function">The function <see cref="Func{TResult}"/>.</param>
        /// <returns>The <see cref="Task{TResult}"/>.</returns>
        public Task<TResult> StartNew<TResult>(Func<TResult> function)
        {
            return Task.Factory.StartNew<TResult>(function);
        }

        /// <summary>
        /// The StartNew.
        /// </summary>
        /// <param name="action">The action <see cref="Action"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task StartNew(Action action)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The StartNew.
        /// </summary>
        /// <param name="action">The action <see cref="Action"/>.</param>
        /// <param name="cancellationToken">The cancellationToken <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task StartNew(Action action, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}