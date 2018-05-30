using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeProg.Common
{
  public  interface IContentMetadata
    {
        string Name { get; set; }

        string Source { get; set; }
    }
}
