namespace ZoeProg.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Common;

    public class TaskService : ITaskService
    {
        public TaskService()
        {
        }

        public Task<TResult> StartNew<TResult>(Func<TResult> function)
        {
            return Task.Factory.StartNew<TResult>(function);
        }

        public Task StartNew(Action action)
        {
            throw new NotImplementedException();
        }

        public Task StartNew(Action action, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}