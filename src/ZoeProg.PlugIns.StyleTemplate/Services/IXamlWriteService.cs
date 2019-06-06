using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZoeProg.PlugIns.StyleTemplate.Services
{
  public  interface IXamlWriteService
    {
        string GetXamlString(ControlTemplate controlTemplate);
    }
}
