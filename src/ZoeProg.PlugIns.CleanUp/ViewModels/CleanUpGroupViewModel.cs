

namespace ZoeProg.PlugIns.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using ZoeProg.Core.Models;
public class CleanUpGroupViewModel : BindableBase
{

    private bool deny;
    private string group;
    //i.e. cannot be deleted
    public bool Deny
    {
        get => this.deny;
        set => this.SetProperty<bool>(ref this.deny, value);
    }

    public string Group
    {
        get => this.group;
        set => this.SetProperty<string>(ref this.group, value);

    }
    public string Key
    {
        get;
    }

    public CleanUpGroupViewModel(string key, string group)
    {
        this.Key = key;
        this.Group = group;
    }
}