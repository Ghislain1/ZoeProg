namespace ZoeProg.PlugIns.InstalledList.ViewModels
{
  using Common;
  using Common.Data;
  using Prism.Mvvm;
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;

  using System.Linq;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;

  public class InstalledViewModel : BindableBase, ITabItem
  {
    private readonly IPackageRepository packageRepository;
    private CancellationTokenSource cancellationTokenSource;
    private ObservableCollection<Package> installedItems;
    private string title;

    public InstalledViewModel(IPackageRepository packageRepository)
    {
      this.packageRepository = packageRepository;
      this.title = "Installed Program";
      this.installedItems = new ObservableCollection<Package>();
      this.cancellationTokenSource = new CancellationTokenSource();
      this.InitializeComponent();
    }

    public string BackgroudImage
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public ObservableCollection<Package> InstalledItems
    {
      get
      {
        return this.installedItems;
      }
      set
      {
        this.installedItems = value;
      }
    }

    public string Title
    {
      get
      {
        return this.title;
      }
    }

    private async void InitializeComponent()
    {
      var resp = await this.packageRepository.GetListInstalledPackages(cancellationTokenSource.Token);
      foreach (var item in resp)
      {
        this.InstalledItems.Add(item);
      }
    }
  }
}