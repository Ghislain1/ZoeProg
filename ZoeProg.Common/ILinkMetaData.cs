using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeProg.Common
{
    public interface ILinkMetadata
    {
        string DisplayName { get; set; }
        string ParentName { get; set; }
        string Source { get; set; }
    }

    public interface IModuleMetadata
    {
        List<ILinkMetadata> SourceLinks { get; set; }
        string Title { get; set; }
    }
}