using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoeProg.PlugIns.Audit.Models;

namespace ZoeProg.PlugIns.Audit.Services
{
    public interface IProcessProvider
    {
        string GetProcessList();
        Task<List<ProcessItem>> GetProcessListAsync();
    }


}