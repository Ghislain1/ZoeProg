namespace ZoeProg.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ZoeProg.Common.Data;

    public interface IPlugInService
    {
        List<FunctionItem> GetFunctionItemList();

        Task<List<FunctionItem>> GetFunctionItemListAsynchronly();

        bool ImplementedIPlugIn(Type plugIn);

        void StoreTitle(string id, string title);

        void StoreTitle(string title);
    }
}