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

namespace ZoeProg.PlugIns.CleanUp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Mvvm;
    using ZoeProg.Core;
    using ZoeProg.PlugIns.CleanUp.Services;

    /// <summary>
    /// TODO:.
    /// </summary>
    public class CleanUpViewModel : BindableBase, IPlugin
    {
        /// <summary>
        /// Defines the canDelete.
        /// </summary>
        private bool canDelete;

        /// <summary>
        /// Defines the cleanupService.
        /// </summary>
        private ICleanupService cleanupService;

        /// <summary>
        /// Defines the deleteCommandDisplayName.
        /// </summary>
        private string deleteCommandDisplayName = "Delete";

        /// <summary>
        /// Defines the isSelected.
        /// </summary>
        private bool isSelected = false;

        /// <summary>
        /// Defines the todos.
        /// </summary>
        private ObservableCollection<string> todos = new ObservableCollection<string>();

        public CleanUpViewModel()
        {
        }

        /// <inheritdoc/>
        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public ICommand Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the CommandParameter.
        /// </summary>
        public Type CommandParameter { get; set; }

        /// <summary>
        /// Gets the DeleteCommand.
        /// </summary>
        public DelegateCommand DeleteCommand { get; private set; }

        /// <summary>
        /// Gets or sets the DeleteCommandDisplayName.
        /// </summary>
        public string DeleteCommandDisplayName
        {
            get
            {
                return this.deleteCommandDisplayName;
            }
            set
            {
                this.SetProperty<string>(ref this.deleteCommandDisplayName, value);
            }
        }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Glyph.
        /// </summary>
        public string Glyph { get; set; } = "\uE81F";

        /// <summary>
        /// Gets the Header.
        /// </summary>
        public string Header => throw new NotImplementedException();

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets a value indicating whether IsBusy.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return this.canDelete;
            }

            set
            {
                if (this.SetProperty<bool>(ref this.canDelete, value))
                {
                    this.DeleteCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsSelected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.SetProperty<bool>(ref this.isSelected, value);
            }
        }

        /// <summary>
        /// Gets or sets the Kind.
        /// </summary>
        public string Kind { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Label.
        /// </summary>
        public string Label { get; set; } = "Clean Up";

        /// <summary>
        /// Gets or sets the NavigatePath.
        /// </summary>
        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets the ScanCommand.
        /// </summary>
        public DelegateCommand ScanCommand { get; private set; }

        /// <summary>
        /// Gets or sets the Tag.
        /// </summary>
        public string Tag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Todos.
        /// </summary>
        public ObservableCollection<string> Todos
        {
            get
            {
                return this.todos;
            }
            set
            {
                if (this.SetProperty<ObservableCollection<string>>(ref this.todos, value))
                {
                    this.DeleteCommandDisplayName = $" Delete({ (value == null ? 0 : value.Count)})";
                }
            }
        }

        /// <summary>
        /// TODO Initializes a new instance of the <see cref="CleanupViewModel"/> class.
        /// </summary>
        /// <param name="cleanupService">.</param>
        private void CleanUpViewModelTdood(ICleanupService cleanupService)
        {
            this.cleanupService = cleanupService ?? throw new ArgumentNullException(nameof(cleanupService));

            this.CommandParameter = this.GetType();

            this.DeleteCommand = new DelegateCommand(async () =>
                        {
                            this.IsBusy = true;
                            await this.cleanupService.RemoveFileAsnyc(this.Todos.ToList());
                            this.Todos.Clear();
                            this.IsBusy = false;
                        });

            this.ScanCommand = new DelegateCommand(async () =>
          {
              var result = new List<string>();
              this.IsBusy = true;
              await this.cleanupService.LoadTempFilesAsync(path => result.Add(path));
              this.Todos.Clear();
              foreach (var item in result)
              {
                  this.Todos.Add(item);
              }

              this.IsBusy = false;
          });
        }
    }
}