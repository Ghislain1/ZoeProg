namespace ZoeProg.Services
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;

    public class PowerShellService : IPowerShellService
    {
        public Task RunCommand(Action<string> onDataReceived, string command)
        {
            return RunCommand(onDataReceived, CancellationToken.None, command);
        }

        public Task<IEnumerable<object>> RunCommand(CancellationToken cancelToken, string command)
        {
            var tcs = new TaskCompletionSource<IEnumerable<object>>();

            Task.Factory.StartNew(() =>
            {
                using (var ps = PowerShell.Create())
                {
                    var collection = ps.AddScript(command).Invoke<object>();

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

        /// <summary>
        /// Talk about this Mathod again ??
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="format"></param>
        /// <returns></returns>

        public Task<IList<T>> RunCommand<T>(string command, string format)
        {
            var tcs = new TaskCompletionSource<IList<T>>();

            Task.Factory.StartNew(() =>
            {
                using (var ps = PowerShell.Create())
                {
                    var customCommand = command + " | " + format;
                    var collection = ps.AddScript(command).Invoke<T>();
                    tcs.TrySetResult(collection);
                }
            }
           );

            return tcs.Task;
        }

        /// <summary>
        /// TODO: Understand what happen here -- Best way for  e.g. Clean process Runs the command.
        /// </summary>
        /// <param name="onCompleted">The on completed.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public Task RunCommand(Action onCompleted, string command)
        {
            var tcs = new TaskCompletionSource<object>();

            Task.Run(() =>
            {
                using (var ps = PowerShell.Create())
                {
                    ps.Streams.Progress.DataAdded += (s, t) =>
                      {
                          s.ToString();
                      };

                    ps.Streams.Error.DataAdded += (s, t) =>
                    {
                        onCompleted();
                    };
                    ps.Streams.Information.DataAdded += (s, t) =>
                    {
                        s.ToString();
                    };

                    ps.InvocationStateChanged += (se, es) =>
                    {
                        if (es.InvocationStateInfo.State == PSInvocationState.Completed)
                        {
                            // onCompleted();
                        }
                    };
                    var collection = ps.AddScript(command).Invoke<string>();

                    tcs.TrySetResult(null);
                }
            });

            return tcs.Task;
        }
    }
}