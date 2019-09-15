namespace ZoeProg.PlugIns.Audit.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Prism.Mvvm;
    using ZoeProg.Core;
    using ZoeProg.PlugIns.Audit.Models;
    using ZoeProg.PlugIns.Audit.Services;

    public class AuditViewModel : BindableBase, IPlugin
    {
        private readonly IProcessProvider processProvider;
        private string glyph = "\uE932";

        private int processCount;

        private ObservableCollection<ProcessItem> processes;

        public AuditViewModel(IProcessProvider processProvider)
        {
            this.CommandParameter = this.GetType();
            this.processProvider = processProvider ?? throw new ArgumentNullException(nameof(processProvider));

            this.LoadProcesses().GetAwaiter();
        }

        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICommand Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Type CommandParameter { get; set; }

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Glyph
        {
            get
            {
                return glyph;
            }
            set { SetProperty(ref glyph, value); }
        }

        public string Header => "Audit";

        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Kind { get; set; } = "Camera";

        // Glyph="&#xE932;" Label="Invoice" Tag="OpenInvoiceMaker" @" &#xE932;";
        public string Label { get; set; } = "Audit";

        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ProcessCount
        {
            get { return processCount; }
            set { SetProperty(ref processCount, value); }
        }

        public ObservableCollection<ProcessItem> Processes
        {
            get { return processes; }
            set { SetProperty(ref processes, value); }
        }

        public string Tag { get; set; } = "OpenAuditMaker";

        public string Title { get; set; } = "Process";

        private async Task LoadProcesses()
        {
            var xa = await this.processProvider.GetProcessListAsync();

            this.Processes = new ObservableCollection<ProcessItem>(xa);
            this.ProcessCount = this.Processes.Count;
        }
    }
}