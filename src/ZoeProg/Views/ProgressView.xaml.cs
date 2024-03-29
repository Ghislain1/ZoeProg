﻿// <copyright file="ProgressView.xaml.cs" company="PlaceholderCompany">
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

namespace ZoeProg.Views
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for ProgressView.xaml.
    /// </summary>
    public partial class ProgressView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressView"/> class.
        /// </summary>
        public ProgressView()
        {
            this.InitializeComponent();
            this.Owner = Application.Current.MainWindow;
            this.Width = this.Owner.ActualWidth;
            this.Height = this.Owner.ActualHeight;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.WindowStartupLocation = this.Owner.WindowStartupLocation;
            this.Top = this.Owner.Top;
            this.Left = this.Owner.Left;
            this.MouseMove += (s, e) => { };
        }
    }
}