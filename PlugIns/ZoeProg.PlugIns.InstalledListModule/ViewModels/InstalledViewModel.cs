namespace ZoeProg.PlugIns.InstalledList.ViewModels
{
  using Common;
  using Common.Data;
  using Prism.Commands;
  using Prism.Mvvm;
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;

  using System.Linq;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;
  using System.Windows.Input;

  public class InstalledViewModel : BindableBase, ITabItem
  {
    private readonly object lockObj;
    private readonly IPackageRepository packageRepository;
    private readonly IProgressService progressService;
    private readonly SemaphoreSlim syncLock;
    private CancellationTokenSource cancellationTokenSource;
    private ObservableCollection<InstalledPackage> installedItems;
    private bool isBusy;
    private CancellationTokenSource loadCancelToken;
    private string title;

    public InstalledViewModel(IProgressService progressService, IPackageRepository packageRepository)
    {
      this.progressService = progressService;
      this.packageRepository = packageRepository;
      this.title = "Installed Packages";

      this.installedItems = new ObservableCollection<InstalledPackage>();

      this.lockObj = new object();
      this.syncLock = new SemaphoreSlim(1);
      this.cancellationTokenSource = null;

      this.LoadCommand = new DelegateCommand(() =>
      {
        this.Load();
      });
    }

    public string BackgroudImage
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public ObservableCollection<InstalledPackage> InstalledItems
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

    public bool IsBusy
    {
      get
      {
        return this.isBusy;
      }
      set
      {
        this.isBusy = value;
        if (value)
        {
          this.progressService.Show();
        }
        else
        {
          this.progressService.Close();
        }
      }
    }

    public ICommand LoadCommand { get; private set; }

    public string Title
    {
      get
      {
        return this.title;
      }
    }

    private async void Load()
    {
      CancellationTokenSource cancellationTokenSource = null;
      List<InstalledPackage> listInstalledPackages = null;
      try
      {
        cancellationTokenSource = new CancellationTokenSource();

        lock (this.lockObj)
        {
          if (cancellationTokenSource != null)
          {
            cancellationTokenSource.Cancel();
          }

          this.cancellationTokenSource = cancellationTokenSource;
        }

        await this.syncLock.WaitAsync();

        this.IsBusy = true;

        listInstalledPackages = await this.packageRepository.GetListInstalledPackages(this.cancellationTokenSource.Token);
      }
      catch (AggregateException agEx)
      {
        if (agEx.InnerExceptions.Count == 1 && (agEx.InnerExceptions.Single() is OperationCanceledException))
        {
        }
        else
        {
          throw;
        }
      }
      catch (OperationCanceledException)
      {
        // log.Trace("Previous load task was cancelled");
      }
      finally
      {
        this.IsBusy = false;

        lock (this.lockObj)
        {
          if (this.cancellationTokenSource == cancellationTokenSource)
          {
            this.loadCancelToken = null;
          }
        }

        if (cancellationTokenSource != null)
        {
          cancellationTokenSource.Dispose();
        }

        this.syncLock.Release();
      }

      foreach (var item in listInstalledPackages)
      {
        this.InstalledItems.Add(item);
      }
      this.progressService.Close();
    }
  }
}