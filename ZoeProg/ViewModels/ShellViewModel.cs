namespace ZoeProg.ViewModels
{
    using System;
    using Prism.Mvvm;
    using Microsoft.Practices.Unity;
    using System.Windows.Input;
    using Prism.Commands;
    using System.Collections.ObjectModel;
    using Prism.Modularity;
    using ZoeProg.Common;
    using ZoeProg.Common.Data;
    using Prism.Regions;
    using System.Linq;

    public class ShellViewModel : BindableBase, IShellViewModel
    {
        private readonly IUnityContainer container;
        private readonly IModuleManager moduleManager;
        private readonly IPlugInService plugInService;
        private bool isBusy;
        private bool isItemSeleted;

        private bool isLeftDrawerOpen;

        private IPlugIn selectedPlugIn;
        private string selectedTab;

        public ShellViewModel(IPlugInService plugInService, IModuleManager moduleManager, IUnityContainer container)
        {
            this.container = container;
            this.moduleManager = moduleManager;
            this.plugInService = plugInService;

            this.DialogHostIdentifier = Guid.NewGuid();
            this.DialogHostIdentifier = Guid.NewGuid();
            this.StartupCommand = new DelegateCommand(RunStartup);
            this.ShutDownCommand = new DelegateCommand(RunShutdown);
            this.OpenManagementCommand = new DelegateCommand(OpenManagement);
            this.PlugInCollection = new ObservableCollection<IPlugIn>();

            this.moduleManager.LoadModuleCompleted += (s, e) =>
              {
                  var type = Type.GetType(e.ModuleInfo.ModuleType);
                  if (!this.plugInService.ImplementedIPlugIn(type))
                  {
                      throw new Exception(e.ModuleInfo.ModuleName + "Must implements IPlugIn");
                  }
                  var instance = Activator.CreateInstance(type, this.container.Resolve<IRegionManager>(), this.container);
                  this.PlugInCollection.Add(instance as IPlugIn);
                  if (this.SelectedPlugIn == null)
                  {
                      this.SelectedPlugIn = this.PlugInCollection.FirstOrDefault();
                  }
              };
        }

        public Guid DialogHostIdentifier { get; }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            private set
            {
            }
        }

        public bool IsLeftDrawerOpen
        {
            get { return this.isLeftDrawerOpen; }
            set
            {
                if (this.SetProperty<bool>(ref this.isLeftDrawerOpen, value))
                {
                }
            }
        }

        public ICommand OpenManagementCommand { get; }
        public ObservableCollection<IPlugIn> PlugInCollection { get; }

        public IPlugIn SelectedPlugIn
        {
            get => this.selectedPlugIn;
            set
            {
                if (this.SetProperty<IPlugIn>(ref this.selectedPlugIn, value))
                {
                    var navigatePath = this.selectedPlugIn.NavigatePath;
                    if (navigatePath != null)
                    {
                        var regionManager = container.Resolve<IRegionManager>();
                        regionManager.RequestNavigate(RegionNames.MainRegion, navigatePath);
                    }
                }
            }
        }

        public ICommand ShutDownCommand { get; }

        public ICommand StartupCommand { get; }

        private async void InitializeComponent()
        {
            var list = await plugInService.GetFunctionItemListAsynchronly();

            foreach (var item in list)
            {
                this.PlugInCollection.Add(item);
            }
        }

        private void OpenManagement()
        {
            throw new NotImplementedException();
        }

        private void RunShutdown()
        {
            throw new NotImplementedException();
        }

        private void RunStartup()
        {
            throw new NotImplementedException();
        }
    }
}