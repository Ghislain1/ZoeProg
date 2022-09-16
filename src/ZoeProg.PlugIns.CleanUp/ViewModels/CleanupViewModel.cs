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
    
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Mvvm;
    using ZoeProg.Core;
     
    using ZoeProg.PlugIns.CleanUp.Services;
    using ZoeProg.PlugIns.ViewModels;

    /// <summary>
    /// TODO:.
    /// </summary>
    public class CleanUpViewModel : BindableBase, IPlugin
    {
        

        /// <summary>
        /// Defines the cleanupService.
        /// </summary>
        private ICleanupService cleanupService;
 

        /// <summary>
        /// Defines the isSelected.
        /// </summary>
        private bool isSelected = false;

        /// <summary>
        /// Defines the todos.
        /// </summary>
        private ObservableCollection<CleanUpItemViewModel> items = new();
        private CancellationTokenSource cancellationTokenSource;

        public CleanUpViewModel(ICleanupService cleanupService)
        {
            this.cleanupService = cleanupService ?? throw new ArgumentNullException(nameof(cleanupService));
            this.ItemsView = CollectionViewSource.GetDefaultView(this.Items);
            this.ItemsView.Filter = item =>
            {
                if (item is CleanUpItemViewModel cleanUpItemViewModel)
                {
                    return File.Exists(cleanUpItemViewModel.CleanUpItem.Path);
                }
                else
                {
                    return true;
                }

            };
            this.cancellationTokenSource = new CancellationTokenSource();

            this.DeleteCommand = new DelegateCommand(async () =>
            {
                this.IsBusy = true;
                await DeleteAction();
                this.IsBusy = false;
                
            }, () => !this.IsBusy);

            this.LoadData().GetAwaiter();


        }

        private Task DeleteAction()
        {

            return Task.Run(() =>
            {
                foreach (var item in this.Items)
                {
                    string combinedPath = Path.Combine(item.CleanUpItem.Group, item.CleanUpItem.Path);

                    try
                    {
                        File.Delete(item.CleanUpItem.Path);
                      
                    }
                    catch (IOException)
                    {
                        item.CleanUpItem.IsLockedFile = true;
                     
                        this.RaisePropertyChanged(nameof(item.CleanUpItem.IsLockedFile));
                    }
                    catch (UnauthorizedAccessException)
                    {
                        
                        item.CleanUpItem.IsUnauthorizedAccess = true;
                        this.RaisePropertyChanged(nameof(item.CleanUpItem.IsLockedFile));
                    }
                }

            });
        }

        private async Task LoadData()
        {
            this.IsBusy = true;
            var filesToClean = await this.cleanupService.GetAllAsync(this.cancellationTokenSource.Token);
            this.Items.Clear();
            foreach (var item in filesToClean)
            {
                this.Items.Add(new CleanUpItemViewModel(item));
            }
         
            this.IsBusy = false;
            this.RaisePropertyChanged(nameof(this.ItemsCount));
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
        bool isBusy;
        /// <summary>
        /// Gets or sets a value indicating whether IsBusy.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                if (this.SetProperty<bool>(ref this.isBusy, value))
                {
                    this.DeleteCommand.RaiseCanExecuteChanged();
                }
                if (!value)
                {
                    this.ItemsView.Refresh();
                    this.RaisePropertyChanged(nameof(this.ItemsCount));
                }
            }
        }
   
        /// <summary>
        /// Gets or sets a value indicating whether IsSelected.
        /// </summary>
        public int ItemsCount => this.Items.Count();
       
        
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
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Todos.
        /// </summary>
        public ObservableCollection<CleanUpItemViewModel> Items
        {
            get => this.items;
            set => this.SetProperty<ObservableCollection<CleanUpItemViewModel>>(ref this.items, value);

        }
        public ICollectionView ItemsView { get; }

   

    }
}
