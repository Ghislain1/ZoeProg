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

    public sealed class ProgressMonitor : ProgressMonitorWrapper, IProgressMonitor
    {
        public ProgressMonitor(IUnityContainer container) : base(container.Resolve<IProgressService>(), container)
        {
        }
    }
}