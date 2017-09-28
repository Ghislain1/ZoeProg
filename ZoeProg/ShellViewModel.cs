namespace ZoeProg
{
  using System;
  using Prism.Mvvm;
  using Microsoft.Practices.Unity;

  public class ShellViewModel : BindableBase, IShellViewModel
  {
    private readonly IUnityContainer container;

    private bool isBusy;

    public ShellViewModel()
    {
    }

    public bool IsBusy
    {
      get
      {
        return this.isBusy;
      }
      private set
      {
      }
    }
  }
}