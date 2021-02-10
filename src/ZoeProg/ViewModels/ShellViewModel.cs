// --------------------------------------------------------------------------------------------------------------
// <copyright file="ShellViewModel.cs" company="CompanyName">
//     Copyright 2021 - GhislainOne Inc.
//     Developer: GHISPC\Zoe ( 10.02.2021 18:00:18 )
// </copyright>
// ---------------------------------------------------------------------------------------------------------------

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
        /// Defines the this.title.
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
            get => this.activatedItem;
            set
            {
                this.SetProperty(ref this.activatedItem, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsPaneOpen.
        /// </summary>
        public bool IsPaneOpen
        {
            get => this.isPaneOpen;
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
            set { this.SetProperty(ref this.title, value); }
        }
    }
}