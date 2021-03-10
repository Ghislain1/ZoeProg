namespace ZoeProg.Infrastructure
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPowershellService
    {
        Task RunCommand(CancellationToken none, string cmd);

        Task RunCommand(string namee, Action<string> cmd);
    }
}