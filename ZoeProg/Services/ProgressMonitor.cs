/// <summary>
/// http://kickjava.com/src/org/eclipse/core/runtime/SubProgressMonitor.java.htm
/// </summary>

namespace ZoeProg.Services
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Views;
    using ZoeProg.Common;
    using ZoeProg.ViewModels;

    public sealed class ProgressMonitor : ProgressMonitorWrapper
    {
        private readonly IUnityContainer container;
        private readonly ProgressView progressView;
        private bool hasSubTask;

        private String JavaDoc
private int nestedBeginTasks;

        private int parentTicks = 0;
        private double scale = 0.0;
        private double sentToParent = 0.0;
        private int style;
        private bool usedUp;
        mainTaskLabel;

        public ProgressMonitor(IUnityContainer container) : base(this)
        {
            this.container = container;
        }

        public bool IsCanceled => throw new NotImplementedException();

        public bool IsCancellable => throw new NotImplementedException();

        public bool IsGeneric => throw new NotImplementedException();

        public string TaskName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BeginTask(string name, int totalWork, bool isCancellable, bool isGeneric)
        {
            throw new NotImplementedException();
        }

        public void BeginTask(string name, int totalWork)
        {
            throw new NotImplementedException();
        }

        public void Done()
        {
            throw new NotImplementedException();
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