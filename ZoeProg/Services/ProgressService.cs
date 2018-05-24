namespace ZoeProg.Services
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Views;
    using ZoeProg.Common;
    using ZoeProg.ViewModels;

    public sealed class ProgressService : NullProgressMonitor, IProgressService
    {
        private readonly IUnityContainer container;
        private ProgressView progressView;

        public ProgressService(IUnityContainer container)
        {
            this.container = container;
            this.progressView = this.container.Resolve<ProgressView>();
        }

        public event Action TaskStart;

        public void Close()
        {
            this.progressView.Close();
            this.progressView = null;
        }

        public void Show()
        {
            if (this.progressView == null)
            {
                this.progressView = this.container.Resolve<ProgressView>();
            }
            this.progressView.Show();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}