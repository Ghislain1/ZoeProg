namespace ZoeProg.ViewModels

{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZoeProg.Common;

    public abstract class ProgressMonitorWrapper : IProgressMonitor
    {
        /** The wrapped progress monitor. */

        private readonly IUnityContainer container;
        private readonly IProgressService progressService;

        /// <summary>
        /// Creates a new wrapper around the given monitor. monitor the progress monitor to forward to
        /// </summary>
        /// <param name="monitor"></param>
        protected ProgressMonitorWrapper(IProgressMonitor monitor, IUnityContainer container)
        {
            if (monitor == null)
            {
                throw new Exception(" null exception..");
            }
            this.container = container;
            this.progressService = monitor as IProgressService;
        }

        public bool IsCanceled => throw new NotImplementedException();

        public bool IsCancellable => throw new NotImplementedException();

        public bool IsGeneric => throw new NotImplementedException();

        public string TaskName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BeginTask(string name, int totalWork, bool isCancellable, bool isGeneric)
        {
            this.progressService.Show();
        }

        public void BeginTask(string name, int totalWork)
        {
            this.progressService.Show();
        }

        public void Done()
        {
            this.progressService.Close();
        }

        public void InternalWorked(double work)
        {
            throw new NotImplementedException();
        }

        public void Worked(int work)
        {
            throw new NotImplementedException();
        }
    }
}