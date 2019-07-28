

namespace ZoeProg.PlugIns.Audit.ViewModels
{
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Audit.Models;
    using ZoeProg.PlugIns.Audit.Services;
    public class AuditViewModel : BindableBase, IPlugin
    {
        private readonly IProcessProvider processProvider;
        public AuditViewModel(IProcessProvider processProvider)
        {
            this.processProvider = processProvider ?? throw new ArgumentNullException(nameof(processProvider));

            this.LoadProcesses().GetAwaiter();
           
        }

        private async  Task LoadProcesses()
        {
          var xa=  await  this.processProvider.GetProcessListAsync();
           
            this.Processes = new ObservableCollection<ProcessItem>(xa);
            this.ProcessCount = this.Processes.Count;
        }

         
        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get; set; } = "Process";
        public string Kind { get; set; } = "Camera";
        public string Header => "Audit";

        ObservableCollection<ProcessItem> processes;
        public ObservableCollection<ProcessItem> Processes
        {
            get { return processes; }
            set { SetProperty(ref processes, value); }
        }
        private int processCount;
        public int  ProcessCount
        {
            get { return processCount; }
            set { SetProperty(ref processCount, value); }
        }
        // Glyph="&#xE932;" Label="Invoice" Tag="OpenInvoiceMaker"

        public string Glyph
        {
            get {
                return glyph;
            }
            set { SetProperty(ref glyph, value); }
        }

        string glyph = "\uE932";// @" &#xE932;";
        public string Label { get; set; } = "Audit";
        public string Tag { get; set; } = "OpenAuditMaker";
        public ICommand Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
