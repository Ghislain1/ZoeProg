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

  public sealed class ProgressService : IProgressService
  {
    private readonly IUnityContainer container;
    private readonly ProgressView progressView;

    public ProgressService(IUnityContainer container)
    {
      this.container = container;
      this.progressView = this.container.Resolve<ProgressView>();
    }

    public void Close()
    {
      this.progressView.Close();
    }

    public void Show()
    {
      this.progressView.Show();
    }

    public void Update()
    {
      throw new NotImplementedException();
    }
  }
}