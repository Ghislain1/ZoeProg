 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using ZoeProg.Common;
using ZoeProg.PlugIns.Audit.Models;

namespace ZoeProg.PlugIns.Audit.Services
{
    public class ProcessProvider : IProcessProvider
    {
        private readonly IPowerShellService powerShellService;
        public ProcessProvider(  IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService ?? throw new ArgumentNullException(nameof(powerShellService));
        }

        public string GetProcessList()
        {
           
            throw new NotImplementedException();
        }

        public async Task<List<ProcessItem>> GetProcessListAsync()
        {
            var list = new List<ProcessItem>();
            var command = "Get-Process | Select-Object -Property *  ";
            var command2 = "Get-Process | Select-Object -Property *  | ConvertTo-Json -Verbose";

            var collection =  await this.powerShellService.RunCommand<PSObject>(command, "Format-List");

            foreach (var item in collection)
            {
                try
                {
                    
                    var process = new ProcessItem();
                    process.Name = item.Members["ProcessName"].Value.ToString();
                    list.Add(process);
                }
                catch (Exception ex )
                {

                    throw;
                }
              
             
            }



            return list;


        }
    }
}
