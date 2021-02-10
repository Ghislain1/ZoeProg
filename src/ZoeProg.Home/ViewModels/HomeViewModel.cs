//--------------------------------------------------------------------------------------------------------------
// <copyright file="HomeViewModel.cs" company="CompanyName">
//  Copyright 2021 - GhislainOne Inc.
//  Developer: GHISPC\Zoe (10.02.2021 17:19:50)
// </copyright>
// ---------------------------------------------------------------------------------------------------------------

namespace ZoeProg.Home.ViewModels
{
    using System;
    using System.Windows.Input;
    using Prism.Mvvm;
    using ZoeProg.Core;

    /// <summary>
    /// Defines the <see cref="HomeViewModel"/>.
    /// </summary>
    public class HomeViewModel : BindableBase, IPlugin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        public HomeViewModel()
        {
            this.CommandParameter = this.GetType();
        }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public string Code { get; set; }

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
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Glyph.
        /// </summary>
        public string Glyph { get; set; } = "\uE80F";

        /// <summary>
        /// Gets the Header.
        /// </summary>
        public string Header => "Home";

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets a value indicating whether IsSelected.
        /// </summary>
        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Kind.
        /// </summary>
        public string Kind { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Label.
        /// </summary>
        public string Label { get; set; } = "Home";

        /// <summary>
        /// Gets or sets the NavigatePath.
        /// </summary>
        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the Tag.
        /// </summary>
        public string Tag { get; set; } = "OpenHomeMaker";

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; } = "Home";
    }
}