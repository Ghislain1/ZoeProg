using Prism.Commands;
using Prism.Mvvm;
using System;
using ZoeProg.Common;

namespace ZoeProg.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private readonly IApplicationCommands applicationCommands;
        private readonly IPowerShellService powerShellService;
        private bool canSave = true;
        private string saveText;
        private ISettingService settingService;

        public SettingsViewModel(ISettingService settingService, IApplicationCommands applicationCommands)
        {
            this.settingService = settingService;
            this.applicationCommands = applicationCommands;
            this.SaveCommand = new DelegateCommand(Save).ObservesCanExecute(() => this.CanSave);

            this.applicationCommands.SaveCommand.RegisterCommand(this.SaveCommand);
        }

        public bool CanSave
        {
            get { return canSave; }
            set { SetProperty(ref canSave, value); }
        }

        public DelegateCommand SaveCommand { get; private set; }

        public string SaveText
        {
            get { return this.saveText; }
            set { SetProperty(ref this.saveText, value); }
        }

        private void Save()
        {
            this.SaveText = $"Saved: {DateTime.Now}";
        }
    }
}