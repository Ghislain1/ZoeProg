using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeProg.Common
{
    public interface IContentMetadata
    {
        List<IContentMetadata> Children { get; set; }
        string Name { get; set; }
        string Source { get; set; }
    }

    public interface IContentMetadataProvider
    {
        List<IContentMetadata> LinkGroups { get; set; }
    }
}