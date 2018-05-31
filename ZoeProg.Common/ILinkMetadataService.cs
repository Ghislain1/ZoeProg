using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeProg.Common
{
    public interface ILinkMetadataService
    {
        List<ILinkMetadata> LinkMetaDataList { get; }

        void Registry(ILinkMetadata linkMetaData);
    }

    public class LinkMetadataService : ILinkMetadataService
    {
        public LinkMetadataService()
        {
            this.LinkMetaDataList = new List<ILinkMetadata>();
        }

        public List<ILinkMetadata> LinkMetaDataList { get; }

        public void Registry(ILinkMetadata linkMetaData)
        {
            this.LinkMetaDataList.Add(linkMetaData);
        }
    }
}