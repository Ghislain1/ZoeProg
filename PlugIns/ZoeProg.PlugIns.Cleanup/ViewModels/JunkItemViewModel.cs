namespace ZoeProg.PlugIns.Cleanup.ViewModels
{
    using Prism.Mvvm;
    using System;
    using ZoeProg.PlugIns.Cleanup.Models;

    public class JunkItemViewModel : BindableBase
    {
        /// <summary>
        /// The full path to the item
        /// </summary>
        private string fullPath;

        private bool isSelected;

        public string FullPath
        {
            get { return fullPath; }
            set { SetProperty(ref fullPath, value); }
        }

        /// <summary>
        /// Indicate if the user has selected a file.
        /// </summary>
        public bool IsSelected
        {
            get { return this.isSelected; }
            set { SetProperty(ref this.isSelected, value); }
        }

        public void Init(JunkFile model)
        {
            this.FullPath = model.FullPath;
            this.IsSelected = false;
        }
    }
}