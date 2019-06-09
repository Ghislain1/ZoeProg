namespace ZoeProg.Common
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPowerShellService
    {
        Task<IEnumerable<object>> RunCommand(CancellationToken cancelToken, string command);

        Task RunCommand(Action<string> onDataReceived, string command);

       


        Task<IList<T>> RunCommand<T>(string command, string format);


        Task RunCommand(Action<string> onDataReceived, CancellationToken cancelToken, string command);
    }
}