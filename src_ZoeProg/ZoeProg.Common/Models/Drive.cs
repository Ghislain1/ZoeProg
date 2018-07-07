using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeProg.Common.Models
{
    public enum ProviderType
    {
        FileSystem,
        Environment,
        Certificate,
        Function,
        Registry,
        WSMan,
    }

    /// <summary>
    /// Model which represents a Drive(SystemDriver): Check Powershell PSDriver
    /// </summary>
    public class Drive
    {
        public double FreeGB { get; set; }
        public string Name { get; set; }
        public ProviderType Provider { get; set; }
        public string Root { get; set; }
        public double UsedGB { get; set; }
    }
}