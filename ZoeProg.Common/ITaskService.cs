namespace ZoeProg.Common
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITaskService
    {
        // Summary: Creates and starts a System.Threading.Tasks.Task`1.
        //
        // Parameters: function: A function delegate that returns the future result to be available
        // through the System.Threading.Tasks.Task`1.
        //
        // Type parameters: TResult: The type of the result available through the System.Threading.Tasks.Task`1.
        //
        // Returns: The started System.Threading.Tasks.Task`1.
        //
        // Exceptions: T:System.ArgumentNullException: The exception that is thrown when the function
        // argument is null.
        Task<TResult> StartNew<TResult>(Func<TResult> function);

        // Summary: Creates and starts a task.
        //
        // Parameters: action: The action delegate to execute asynchronously.
        //
        // Returns: The started task.
        //
        // Exceptions: T:System.ArgumentNullException: The action argument is null.
        Task StartNew(Action action);

        // Summary: Creates and starts a System.Threading.Tasks.Task.
        //
        // Parameters: action: The action delegate to execute asynchronously.
        //
        // cancellationToken: The System.Threading.Tasks.TaskFactory.CancellationToken that will be
        // assigned to the new task.
        //
        // Returns: The started System.Threading.Tasks.Task.
        //
        // Exceptions: T:System.ObjectDisposedException: The provided
        // System.Threading.CancellationToken has already been disposed.
        //
        // T:System.ArgumentNullException: The exception that is thrown when the action argument is null.
        Task StartNew(Action action, CancellationToken cancellationToken);
    }
}