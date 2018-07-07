namespace ZoeProg.Common
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPowerShellService
    {
        Task<IEnumerable<string>> RunCommand(CancellationToken cancelToken, string command);

        Task RunCommand(Action<string> onDataReceived, string command);

        Task<IEnumerable<PSObject>> RunCommand(string command);


   
        Task RunCommand(Action<string> onDataReceived, CancellationToken cancelToken, string command);
    }
}