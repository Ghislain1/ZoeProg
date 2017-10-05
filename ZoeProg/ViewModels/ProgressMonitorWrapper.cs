namespace ZoeProg.ViewModels

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZoeProg.Common;

    public abstract class ProgressMonitorWrapper : IProgressMonitor
    {
        /** The wrapped progress monitor. */

        private IProgressMonitor progressMonitor;

        /// <summary>
        /// Creates a new wrapper around the given monitor. monitor the progress monitor to forward to
        /// </summary>
        /// <param name="monitor"></param>
        protected ProgressMonitorWrapper(IProgressMonitor monitor)
        {
            if (monitor == null)
            {
                throw new Exception(" null exception..");
            }
            this.progressMonitor = monitor;
        }

        public bool IsCanceled => this.progressMonitor.IsCanceled;

        public bool IsCancellable => this.progressMonitor.IsCancellable;

        public bool IsGeneric => this.progressMonitor.IsGeneric;

        public string TaskName { get => this.progressMonitor.TaskName; set => this.progressMonitor.TaskName = value; }

        public void BeginTask(string name, int totalWork, bool isCancellable, bool isGeneric)
        {
            this.progressMonitor.BeginTask(name, totalWork, isCancellable, isGeneric);
        }

        public void BeginTask(string name, int totalWork)
        {
            this.progressMonitor.BeginTask(name, totalWork);
        }

        public void Done()
        {
            this.progressMonitor.Done();
        }

        public void InternalWorked(double work)
        {
            this.progressMonitor.InternalWorked(work);
        }

        public void Worked(int work)
        {
            this.progressMonitor.Worked(work);
        }
    }
}