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

namespace ZoeProg.PlugIns.CleanUp.ViewModels;

using System;
using System.Collections.Generic;
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
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

/// <summary>
/// TODO:.
/// </summary>
public class CleanUpViewModel : BindableBase, IPlugin
{

    private readonly IDialogCoordinator dialogCoordinator;
    private readonly ICleanupService cleanupService;
    private bool isBusy;
    private bool isSelected = false;
    private ObservableCollection<CleanUpItemViewModel> items = new();
    private ObservableCollection<CleanUpGroupViewModel> groupCollection = new();
    private CancellationTokenSource cancellationTokenSource = new();

    public CleanUpViewModel(ICleanupService cleanupService, IDialogCoordinator dialogCoordinator)
    {
        this.cleanupService = cleanupService ?? throw new ArgumentNullException(nameof(cleanupService));
        this.dialogCoordinator = dialogCoordinator ?? throw new ArgumentNullException(nameof(dialogCoordinator));
        this.InitGroup();
        this.ItemsView = CollectionViewSource.GetDefaultView(this.Items);
        this.ItemsView.Filter = item => this.OnFilter(item);

        // Commands
        this.ScanCommand = new DelegateCommand(async () =>
        {
            await this.LoadDataAsync();
        }, () => !this.IsBusy);

        this.DeleteCommand = new DelegateCommand(async () =>
        {
            await this.DeleteDataAsync();

        }, () => !this.IsBusy && this.Items is not null && this.Items.Any(ite => !ite.Deny));
    }

    private void InitGroup()
    {
        this.GroupCollection.Clear();
        var dic = this.cleanupService.GetPresetDirectories();
        foreach (var item in dic.Keys)
        {
            this.GroupCollection.Add(new CleanUpGroupViewModel(item, dic[item]));
        }
    }

    private bool OnFilter(object item)
    {

        if (item is CleanUpItemViewModel cleanUpItemViewModel)
        {
            return File.Exists(cleanUpItemViewModel.CleanUpItem.Path);
        }

        return true;
    }

    private async Task LoadDataAsync()
    {
        this.IsBusy = true;

        var controller = await this.dialogCoordinator.ShowProgressAsync(this, "[Ghislain-ToDo] Please wait...", "Progress message");
        controller.SetIndeterminate();
        this.Items.Clear();
        foreach (var demoFolder in this.GroupCollection.Where(i => i.IsChecked && i.FullPath is not null))
        {
            var filesToClean = await this.cleanupService.GetAllAsync(demoFolder.FullPath, this.cancellationTokenSource.Token);

            foreach (var item in filesToClean)
            {
                this.Items.Add(new CleanUpItemViewModel(item, demoFolder.GroupName));
            }
        }
        await controller.CloseAsync();
        this.IsBusy = false;

    }

    private async Task DeleteDataAsync()
    {
        this.IsBusy = true;
        var controller = await this.dialogCoordinator.ShowProgressAsync(this, "[Ghislain-ToDo] Please wait...", "Deleting File ... ");
        controller.SetIndeterminate();
        foreach (var item in this.Items)
        {
            await this.cleanupService.DeleteAsync(item.CleanUpItem.Path, e =>
            {
                item.Deny = true;

            });
        }
        await controller.CloseAsync();
        this.IsBusy = false;

    }
    public ICommand? Command { get; set; }

    public Type? CommandParameter { get; set; }

    public DelegateCommand DeleteCommand { get; private set; }


    public string Description { get; set; } = "I , clean up feature!";

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
                this.ScanCommand.RaiseCanExecuteChanged();
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
        get => this.isSelected;

        set => this.SetProperty<bool>(ref this.isSelected, value);
    }

    /// <summary>
    /// Gets or sets the Kind.
    /// </summary>
    public string Kind { get; set; } = "Clock";

    /// <summary>
    /// Gets or sets the Label.
    /// </summary>
    public string Header { get; set; } = "Clean Up";

    /// <summary>
    /// Gets or sets the NavigatePath.
    /// </summary>
    public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    /// <summary>
    /// Gets the ScanCommand.
    /// </summary>
    public DelegateCommand ScanCommand { get; private set; }

    /// <summary>
    /// Gets or sets the Todos.
    /// </summary>
    public ObservableCollection<CleanUpItemViewModel> Items
    {
        get => this.items;
        set => this.SetProperty<ObservableCollection<CleanUpItemViewModel>>(ref this.items, value);
    }

    public ObservableCollection<CleanUpGroupViewModel> GroupCollection
    {
        get => this.groupCollection;
        set => this.SetProperty(ref this.groupCollection, value);

    }

    public ICollectionView ItemsView { get; }

}