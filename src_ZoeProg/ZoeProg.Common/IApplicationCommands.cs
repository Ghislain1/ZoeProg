namespace ZoeProg.Common
{
    using Prism.Commands;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
    }
}