using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeProg.PlugIns.Uninstall.Models
{
   public class InstalledPackage
    {
        public string Title { get; set; }


        public string Name { get; set; }

        public string Version { get; set; }
        public string IdentifyingNumber { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }
}
