namespace ZoeProg.Services
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.IO;
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

        public Task<IEnumerable<string>> RunCommand(string command)
        {
            ///Get - ItemPropertyValue - Path C: \Users\Test\Documents\ModuleToAssembly - Name LastWriteTime,CreationTime,Root
            ///
            var format = @"Get-ItemPropertyValue -Path {0} -Name LastWriteTime,CreationTime";
            var tcs = new TaskCompletionSource<IEnumerable<string>>();

            Task.Factory.StartNew(() =>
            {
                using (var ps = PowerShell.Create())
                {
                    var collection = ps.AddScript(command).Invoke<string>();
                    var itemPropertyCollection = new List<string>();
                    foreach (var fullNameFile in collection)
                    {
                        string internalCMD = string.Format(format, fullNameFile);
                        var itemProperty = ps.AddScript(internalCMD).Invoke<string>();

                        //TODO: now just a name
                        var fileName = Path.GetFileNameWithoutExtension(fullNameFile);
                        itemPropertyCollection.Add(fileName);
                    }
                    tcs.TrySetResult(itemPropertyCollection);
                }
            }
           );

            return tcs.Task;

            //var tcs = new TaskCompletionSource<IEnumerable<string>>();
            //Func<Task<IEnumerable<string>>> func = () =>
            //{
            //    using (var ps = PowerShell.Create())
            //    {
            //        var collection = ps.AddScript(command).Invoke<string>();
            //        var itemPropertyCollection = new List<string>();
            //        foreach (var fullNameFile in collection)
            //        {
            //            string internalCMD = string.Format(format, fullNameFile);
            //            var itemProperty = ps.AddScript(internalCMD).Invoke<string>();

            //            //TODO: now just a name
            //            var fileName = Path.GetFileNameWithoutExtension(fullNameFile);
            //            itemPropertyCollection.Add(fileName);
            //        }
            //        tcs.TrySetResult(itemPropertyCollection);
            //    }
            //    return tcs.Task;
            //};
            //return this.taskService.StartNew<Task<IEnumerable<string>>>(func).Result;
        }
    }
}