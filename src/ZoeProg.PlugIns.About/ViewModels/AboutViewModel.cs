//--------------------------------------------------------------------------------------------------------------
// <copyright file="HomeViewModel.cs" company="CompanyName">
//  Copyright 2021 - GhislainOne Inc.
//  Developer: GHISPC\Zoe (10.02.2021 17:19:50)
// </copyright>
// ---------------------------------------------------------------------------------------------------------------

namespace ZoeProg.PlugIns.Home.ViewModels;

using System;
using System.Windows.Input;
using Prism.Mvvm;
using ZoeProg.Core;

/// <summary>
/// Defines the <see cref="AboutViewModel"/>.
/// </summary>
public class AboutViewModel : BindableBase, IPlugin
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
    /// </summary>
    public AboutViewModel()
    {
        this.CommandParameter = this.GetType();
    }

   

    /// <summary>
    /// Gets or sets the Command.
    /// </summary>
    public ICommand Command { get; set; }

    /// <summary>
    /// Gets or sets the CommandParameter.
    /// </summary>
    public Type CommandParameter { get; set; }

    /// <summary>
    /// Gets or sets the Description.
    /// </summary>
    public string Description => " I m About feature !";

   

    /// <summary>
    /// Gets the Header.
    /// </summary>
    public string Header { get; set; }= "About";

 

    /// <summary>
    /// Gets or sets a value indicating whether IsSelected.
    /// </summary>
    public bool IsSelected { get  ; set  ; }

    /// <summary>
    /// Gets or sets the Kind.
    /// </summary>
    public string Kind => "About";     

    /// <summary>
    /// Gets or sets the NavigatePath.
    /// </summary>
    public string NavigatePath { get ; set ; }

    

  
 
}