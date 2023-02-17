

namespace ZoeProg.PlugIns.CleanUp.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using ZoeProg.Core.Models;
public class CleanUpGroupViewModel : BindableBase
{

    private bool isChecked;
    private string group;
    private string fullPath;

    public bool IsChecked
    {
        get => this.isChecked;
        set => this.SetProperty<bool>(ref this.isChecked, value);
    }

    public string? GroupName
    {
        get;
    }

    public string? FullPath
    {
        get;

    }

    public CleanUpGroupViewModel(string groupName, string fullPath)
    {
        this.GroupName = groupName;
        this.FullPath = fullPath;
    }
}