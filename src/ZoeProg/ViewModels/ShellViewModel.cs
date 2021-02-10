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

namespace ZoeProg.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;

    /// <summary>
    /// Note: we call this triple-slash-comments.
    /// </summary>
    public class ShellViewModel : BindableBase, IShellViewModel
    {
        /// <summary>
        /// Defines the activatedItem.
        /// </summary>
        private object activatedItem;

        /// <summary>
        /// Defines the isPaneOpen.
        /// </summary>
        private bool isPaneOpen;

        /// <summary>
        /// Defines the title.
        /// </summary>
        private string title = "ZoeProg - Tool - ";

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        public ShellViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the ActivatedItem.
        /// </summary>
        public object ActivatedItem
        {
            get { return this.activatedItem; }
            set
            {
                this.SetProperty(ref activatedItem, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsPaneOpen.
        /// </summary>
        public bool IsPaneOpen
        {
            get { return this.isPaneOpen; }
            set
            {
                this.SetProperty(ref this.isPaneOpen, value);
            }
        }

        /// <summary>
        /// Gets the NavigateCommand.
        /// </summary>
        public DelegateCommand<object> NavigateCommand { get; private set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}