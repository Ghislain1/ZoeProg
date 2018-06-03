namespace ZoeProg.Services
{
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;
    //using Unity;
    //using ZoeProg.Common;
    //using ZoeProg.Common.Data;

    //public sealed class PlugInService : IPlugInService
    //{
    //    private readonly IUnityContainer container;
    //    private readonly IDictionary<Guid, string> dict;

    // public PlugInService(IUnityContainer container) { this.container = container; this.dict = new
    // Dictionary<Guid, string>(); }

    // public List<FunctionItem> GetFunctionItemList() { List<FunctionItem> collec = new
    // List<FunctionItem>(); foreach (var item in this.dict.Where(i => i.Key != null)) { var fItem =
    // new FunctionItem() { Title = item.Value, Id = item.Key.ToString() }; collec.Add(fItem); }
    // return collec; }

    // public Task<List<FunctionItem>> GetFunctionItemListAsynchronly() {
    // TaskCompletionSource<List<FunctionItem>> taskCompletion = new TaskCompletionSource<List<FunctionItem>>();

    // var task = Task.Factory.StartNew(() => { var res = this.GetFunctionItemList();

    // System.Threading.Thread.Sleep(3000 * 4); taskCompletion.SetResult(res); });

    // return taskCompletion.Task; }

    // public bool ImplementedIPlugIn(Type plugInType) { bool result = false; if (plugInType == null)
    // { return result; }

    // if (plugInType.GetInterfaces().Contains(typeof(IPlugIn))) { result = true; } return result; }

    // public void StoreTitle(string id, string title) { //ToDO }
    //    public void StoreTitle(string title)
    //    {
    //        Guid id = Guid.NewGuid();
    //        dict.Add(id, title);
    //    }
    //}
}