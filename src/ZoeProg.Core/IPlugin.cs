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

namespace ZoeProg.Core;

using System;
using System.Windows.Input;

/// <summary>
/// Defines the <see cref="IPlugin"/>.
/// </summary>
public interface IPlugin
{

    /// <summary>
    /// Gets or sets the Command.
    /// </summary>
    ICommand Command { get; set; }

    /// <summary>
    /// Gets or sets the CommandParameter.
    /// </summary>
    Type CommandParameter { get; set; }

    /// <summary>
    /// Gets or sets the Description. for tooltip
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Gets or sets a value indicating whether IsSelected.
    /// </summary>
    bool IsSelected { get; set; }

    /// <summary>
    /// Gets or sets the Kind To interact with Material Design PackIcon.
    /// </summary>
    string Kind { get; }

    /// <summary>
    /// Gets or sets the Label.
    /// </summary>
    string Header { get; }

    /// <summary>
    /// Gets or sets the NavigatePath.
    /// </summary>
    string NavigatePath { get; set; }


}