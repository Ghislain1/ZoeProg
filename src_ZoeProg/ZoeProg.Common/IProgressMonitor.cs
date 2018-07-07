/// <summary>
/// http://kickjava.com/src/org/eclipse/core/runtime/ProgressMonitorWrapper.java.htm this is not my code
/// </summary>

namespace ZoeProg.Common
{
    public interface IProgressMonitor
    {
        /// <summary>
        /// Returns whether cancelation of current operation has been requested.
        /// </summary>
        bool IsCanceled { get; }

        /// <summary>
        /// </summary>
        bool IsCancellable { get; }

        /// <summary>
        /// Indicating an amount of work is unknown.
        /// </summary>
        bool IsGeneric { get; }

        /// <summary>
        /// Sets the task name to the given value.
        /// </summary>
        string TaskName { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="totalWork"></param>
        /// <param name="isCancellable"></param>
        /// <param name="isGeneric"></param>
        void BeginTask(string name, int totalWork, bool isCancellable, bool isGeneric);

        /// <summary>
        /// Notifies that the main task is beginning.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="totalWork"></param>
        void BeginTask(string name, int totalWork);

        /// <summary>
        /// Notifies that the work is done; that is, either the main task is completed or the user
        /// canceled it.
        /// </summary>
        void Done();

        /// <summary>
        /// Internal method to handle scaling correctly.
        /// </summary>
        /// <param name="work"></param>
        void InternalWorked(double work);

        /// <summary>
        /// Notifies that a given number of work unit of the main task has been completed. Note that
        /// this amount represents an installment, as opposed to a cumulative amount of work done to date.
        /// </summary>
        /// <param name="work">a non-negative number of work units just completed.</param>
        void Worked(int work);
    }
}