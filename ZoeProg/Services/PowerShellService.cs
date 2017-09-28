namespace ZoeProg.Services
{
  using Common;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Management.Automation;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;

  public class PowerShellService : IPowerShellService
  {
    public Task RunCommand(Action<string> onDataReceived, string command)
    {
      return RunCommand(onDataReceived, CancellationToken.None, command);
    }

    public Task<IEnumerable<string>> RunCommand(CancellationToken cancelToken, string command)
    {
      var tcs = new TaskCompletionSource<IEnumerable<string>>();

      Task.Factory.StartNew(() =>
      {
        using (var ps = PowerShell.Create())
        {
          var collection = ps.AddScript(command).Invoke<string>();

          tcs.TrySetResult(collection);
        }
      });

      return tcs.Task;
    }

    public Task RunCommand(Action<string> onDataReceived, CancellationToken cancelToken, string command)
    {
      var tcs = new TaskCompletionSource<object>();

      Task.Factory.StartNew(() =>
      {
        using (var ps = PowerShell.Create())
        {
          var collection = ps.AddScript(command).Invoke<string>();
          foreach (var line in collection)
          {
            onDataReceived(line);
          }

          tcs.TrySetResult(null);
        }
      }, cancelToken);

      return tcs.Task;
    }
  }
}