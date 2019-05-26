namespace ZoeProg.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class TaskService
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