using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeProg.PlugIns.StyleTemplate.Services
{
   public interface IWpfControlProvider
    {
        List<Type> RetrieveControls();
        
    }
}
