namespace ZoeProg.PlugIns.InstalledList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using ZoeProg.Common.Data;

    public class InstalledListModule : PlugInBase, IPlugIn
    {
        //private readonly IUnityContainer container;
        //private readonly IPlugInService plugInService;
        //private readonly IRegionManager regionManager;
        private string code;

        private string description;
        private string id;
        private bool isSelected;
        private string title;

        //public InstalledListModule(IRegionManager regionManager, IUnityContainer container) : base()
        //{
        //    this.regionManager = regionManager;
        //    this.container = container;
        //    base.NavigatePath = "InstalledListView";
        //    base.Title = "Installed Package";
        //}

        public void Initialize()
        {
            this.IsSelected = true;
        }
    }
}